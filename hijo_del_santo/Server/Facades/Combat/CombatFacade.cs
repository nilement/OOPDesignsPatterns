using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Objects;
using Objects.PveOpponent.Opponents;
using Server.Facades.User;

namespace Server.Facades.Combat
{
    [Serializable]
    public class CombatFacade : ICombatFacade
    {
        public void WriteToHistory(Opponent opponent, int characterId)
        {
            var query =
                $"insert into {Database.OpponentHistoryTable} (Id, Name, Strength, Agility, Intelligence, Level, Experience, Gold, SummonerCount, CharacterId, OpponentCategory) " +
                $"values ('{opponent.Id}', '{opponent.Name}', '{opponent.Strength}', '{opponent.Agility}', '{opponent.Intelligence}', '{opponent.Level}', '{opponent.Experience}', '{opponent.Gold}'" +
                $", '{opponent.SummonerCount}', '{characterId}', '{(int)opponent.Category}')";

            using (var database = new Database())
            {
                try
                {
                    var connection = database.GetConnection();
                    new SqlCommand(query, connection).ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
               
            }
        }

        public void UpdateCharacter(Opponent opponent, int characterId, bool hasWon)
        {
            var userFacade = new UserFacade();
            var character = userFacade.GetCharacter(new Request<int> {Data = characterId}).Result;

            var hasLeveledUp = hasWon && character.Experience + opponent.Experience > character.Level * 100;

            string query;
            if (hasLeveledUp)
            {
                var random = Common.Random;
                query =
                    $"Update {Database.CharacterTable} SET Strength = '{character.Strength + random.Next(1, 3)}', Agility = '{character.Agility + random.Next(1, 3)}', " +
                    $"Intelligence = '{character.Intelligence + random.Next(1, 3)}', Level = '{character.Level + 1}', Experience = '{character.Experience + opponent.Experience - character.Level * 100}', " +
                    $"Gold = '{character.Gold + opponent.Gold}' where Id = {characterId}";
            }
            else
            {
                query = hasWon
                    ? $"Update {Database.CharacterTable} SET Experience = '{character.Experience + opponent.Experience}' where Id = {characterId}"
                    : $"Update {Database.CharacterTable} SET Experience = '{character.Gold - opponent.Gold}' where Id = {characterId}";
            }


            using (var database = new Database())
            {
                var connection = database.GetConnection();
                try
                {
                    new SqlCommand(query, connection).ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }
            }
        }


        public void UpdateCharacter(Character opponent, int characterId, bool hasWon)
        {
            var userFacade = new UserFacade();
            var character = userFacade.GetCharacter(new Request<int> {Data = characterId}).Result;

            var hasLeveledUp = hasWon && character.Experience + opponent.Experience > character.Level * 100;

            string query;
            if (hasLeveledUp)
            {
                var random = Common.Random;
                query =
                    $"Update {Database.CharacterTable} SET Strength = '{character.Strength + random.Next(1, 3)}', Agility = '{character.Agility + random.Next(1, 3)}', " +
                    $"Intelligence = '{character.Intelligence + random.Next(1, 3)}', Level = '{character.Level + 1}', Experience = '{character.Experience - opponent.Level * 100}', " +
                    $"Gold = '{character.Gold + opponent.Gold}' where Id = {characterId}";
            }
            else
            {
                query = hasWon
                    ? $"Update {Database.CharacterTable} SET Experience = '{character.Experience + opponent.Experience}' where Id = {characterId}"
                    : $"Update {Database.CharacterTable} SET Experience = '{character.Gold - opponent.Gold}' where Id = {characterId}";
            }


            using (var database = new Database())
            {
                var connection = database.GetConnection();
                try
                {
                    new SqlCommand(query, connection).ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void FinishPveFight(Opponent opponent, int characterId, bool hasWon)
        {
            UpdateCharacter(opponent, characterId, hasWon);
            WriteToHistory(opponent, characterId);
        }


        public List<Opponent> GetHistory(Request<int> characterId)
        {
            var query = $"SELECT top(10) * FROM {Database.OpponentHistoryTable} Where CharacterId = {characterId.Data}";
            var history = new List<Opponent>(10);
            using (var database = new Database())
            {
                var connection = database.GetConnection();
                try
                {
                    var reader = new SqlCommand(query, connection).ExecuteReader();
                    while (reader.Read())
                    {
                        history.Add(OpponentFactory.RestoreOpponent(reader.GetGuid(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3),
                            reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(7), (OpponentCategory)reader.GetInt32(8), reader.GetInt32(6)));
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return history;
        }
    }
}
