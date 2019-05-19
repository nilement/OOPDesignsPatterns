using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Objects;
using Objects.Items;
using Server.Loggers;

namespace Server.Facades.User
{
    public class UserFacade : IUserFacade
    {
        private readonly SessionStore _sessionStore = SessionStore.GetSessionStore();
        private static Logger _consoleLogger;

        public UserFacade()
        {
            _consoleLogger = ConsoleLogger.GetLogger();
            _consoleLogger.SetNext(FileLogger.GetLogger());
        }

        public Response<Guid> Login(Account account)
        {
            var md5Alg = MD5.Create();
            var hashedPass = md5Alg.ComputeHash(Encoding.ASCII.GetBytes(account.Password)).ToStringRedux();
            var query = "select * from " + Database.AccountTable + $" where username = '{account.Username}' and password = '{hashedPass}'";
            using (var database = new Database())
            {
                var connection = database.GetConnection();
                var reader = new SqlCommand(query, connection).ExecuteReader();
                if (!reader.HasRows)
                {
                    return Response<Guid>.ReturnBadRequest("Wrong username or password");
                }

                var loginResponse = _sessionStore.Login(account.Username);
                return loginResponse;
            }
        }

        public Response<Guid> Registration(Account account)
        {
            var md5Alg = MD5.Create();
            var hashedPass = md5Alg.ComputeHash(Encoding.ASCII.GetBytes(account.Password)).ToStringRedux();
            var query = $"insert into {Database.AccountTable} (username, password) values ('{account.Username}', '{hashedPass}')";

            using (var database = new Database())
            {
                var connection = database.GetConnection();
                try
                {
                    new SqlCommand(query, connection).ExecuteNonQuery();
                }
                catch
                {
                    return Response<Guid>.ReturnBadRequest("Username already exists");
                }
            }

            return _sessionStore.Login(account.Username);
        }

        public Response<List<Character>> GetAccountCharacters(Request accountId)
        {
            var username = _sessionStore.GetUsername(accountId.SessionId);
            var query = $"select * from {Database.CharacterTable} where AccountUsername = '{username}'";
            using (var database = new Database())
            {
                var connection = database.GetConnection();
                var reader = new SqlCommand(query, connection).ExecuteReader();

                var list = new List<Character>();
                while (reader.Read())
                {
                    list.Add(new Character(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4),
                        reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7)));
                }

                return Response<List<Character>>.AddResult(list);
            }
        }

        public Response<bool> CreateCharacter(Request<string> characterName)
        {
            var character = new Character(characterName.Data);
            var insertQuery = character.GetInsertQuery(Database.CharacterTable, true,
                new Tuple<string, object>("AccountUsername", _sessionStore.GetUsername(characterName.SessionId)));
            using (var database = new Database())
            {
                var connection = database.GetConnection();
                try
                {
                    var count = new SqlCommand(insertQuery, connection).ExecuteNonQuery();

                    if (count != 1)
                    {
                        return Response<bool>.ReturnBadRequest("Something bad happened");
                    }
                }
                catch
                {
                    return Response<bool>.ReturnBadRequest("Something even worse happened");
                }

                return Response<bool>.AddResult(true);
            }
        }

        public Response<Character> GetCharacter(Request<int> characterId)
        {
            var query = "select * from " + Database.CharacterTable + $" where id = '{characterId.Data}'";
            using (var database = new Database())
            {
                var connection = database.GetConnection();
                var reader = new SqlCommand(query, connection).ExecuteReader();

                if (!reader.Read())
                {
                    return Response<Character>.ReturnBadRequest("Character doesn't exist lol");
                }

                var character = new Character(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4),
                    reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7));

                AddItemsToCharacter(character, characterId.SessionId, character.Id);

                return Response<Character>.AddResult(character);
            }
        }

        public Response<bool> SelectCharacter(Request<Character> characterRequest)
        {
            AddItemsToCharacter(characterRequest.Data, characterRequest.SessionId, characterRequest.Data.Id);

            return Response<bool>.AddResult(_sessionStore.SetSessionCharacter(characterRequest.SessionId, characterRequest.Data));
        }

        public Response<List<Item>> GetItems(Request<int> characterId)
        {
            var query = "select * from " + Database.ItemTable + $" where CharacterId = '{characterId.Data}'";
            using (var database = new Database())
            {
                var connection = database.GetConnection();
                var reader = new SqlCommand(query, connection).ExecuteReader();
                var list = new List<Item>();
                while (reader.Read())
                {
                    list.Add(ItemFactory.CreateItem(reader.GetGuid(0), reader.GetString(1), reader.GetDouble(2), reader.GetInt32(3),
                        reader.GetString(4),
                        reader.GetInt32(5), reader.GetInt32(6), (ItemCategory) reader.GetInt32(7), reader.GetBoolean(9)));
                }


                return Response<List<Item>>.AddResult(list);
            }
        }

        public Response<bool> EquipItem(Request<CharacterItemDto> characterItemRequest)
        {
            AddItemsToCharacter(characterItemRequest.Data.Character, characterItemRequest.SessionId, characterItemRequest.Data.Character.Id);

            var itemToEquip = characterItemRequest.Data.Character.Items.FirstOrDefault(x => x.Id == characterItemRequest.Data.Item.Id);
            if (itemToEquip == null)
            {
                return Response<bool>.ReturnBadRequest("You do not have that item.");
            }

            var category = itemToEquip.Category;
            var currentlyEquipped = characterItemRequest.Data.Character.Items.FirstOrDefault(x => x.Category == category && x.IsEquipped);
            using (var database = new Database())
            {
                string query;
                var connection = database.GetConnection();

                if (currentlyEquipped != null)
                {
                    query = $"UPDATE {Database.ItemTable} set IsEquipped = '0' where Id = '{currentlyEquipped.Id}'";
                    currentlyEquipped.IsEquipped = false;
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                query = $"UPDATE {Database.ItemTable} set IsEquipped = '1' where Id = '{characterItemRequest.Data.Item.Id}'";
                itemToEquip.IsEquipped = true;

                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }


            return Response<bool>.AddResult(true);
        }

        public Response<bool> UnequipItem(Request<CharacterItemDto> characterItemRequest)
        {
            AddItemsToCharacter(characterItemRequest.Data.Character, characterItemRequest.SessionId, characterItemRequest.Data.Character.Id);

            var currentlyEquipped = characterItemRequest.Data.Character.Items.FirstOrDefault(x => x.Id == characterItemRequest.Data.Item.Id);
            using (var database = new Database())
            {
                var connection = database.GetConnection();

                if (currentlyEquipped != null)
                {
                    var query = $"UPDATE {Database.ItemTable} set IsEquipped = '0' where Id = '{currentlyEquipped.Id}'";
                    currentlyEquipped.IsEquipped = false;
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }


            return Response<bool>.AddResult(true);
        }

        public Response<Character> CheatSetStat(Request<CheatRequest> request)
        {
            _consoleLogger.Message($"{request.SessionId} session is trying to make their stat {request.Data.Stat} to {request.Data.Value}",
                LogType.Console);
            var characterId = _sessionStore.GetCharacter(request.SessionId).Id;
            var stat = request.Data.Stat;
            var query =
                $"UPDATE {Database.CharacterTable} set {stat}={request.Data.Value} where Id = '{characterId}'";
            var selectQuery = $"select * from {Database.CharacterTable} where Id = '{characterId}'";
            using (var database = new Database())
            {
                var connection = database.GetConnection();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }

                ;
                var reader = new SqlCommand(selectQuery, connection).ExecuteReader();
                if (!reader.Read())
                {
                    return Response<Character>.ReturnBadRequest("Character doesn't exist bab");
                }

                var character = new Character(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4),
                    reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7));
                AddItemsToCharacter(character, request.SessionId, characterId);
                return Response<Character>.AddResult(character);
            }
        }

        private void AddItemsToCharacter(Character character, Guid sessionGuid, int characterId)
        {
            character.Items = GetItems(new Request<int> {Data = characterId, SessionId = sessionGuid}).Result;
        }
    }
}