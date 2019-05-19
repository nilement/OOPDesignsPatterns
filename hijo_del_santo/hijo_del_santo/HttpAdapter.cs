using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Objects;
using Objects.Events;
using Objects.Items;
using Objects.PveOpponent.Opponents;

namespace hijo_del_santo
{
    class HttpAdapter : IServerConnection
    {
        public static HttpClient Client = new HttpClient();
        public static string address = "http://10.151.11.128:8080/";
        //public static string address = "http://192.168.88.232:8080/";

        public async Task<Response<Guid>> Login(Account content)
        {
            var byteArr = new ByteArrayContent(Utils.ObjectToByteArray(content));
            var response = Client.PostAsync(address + "login", byteArr).Result;
            var redux = await response.Content.ReadAsByteArrayAsync();
            return (Response<Guid>)Utils.ByteArrayToObject(redux);
        }

        public async Task<Response<Guid>> Register(Account content)
        {
            var byteArr = new ByteArrayContent(Utils.ObjectToByteArray(content));
            var response = Client.PostAsync(address + "/register", byteArr).Result;
            var redux =  await response.Content.ReadAsByteArrayAsync();
            return (Response<Guid>)Utils.ByteArrayToObject(redux);
        }

        public async Task<Response<List<Character>>> GetAccountCharacters(Guid sessionId)
        {
            var request = new Request {SessionId = sessionId};
            var byteArr = Utils.ObjectToByteArray(request);
            var byteArrContent = new ByteArrayContent(byteArr);
            var response = await Client.PostAsync(address + "/characterList", byteArrContent);
            var redux = response.Content.ReadAsByteArrayAsync().Result;
            return (Response<List<Character>>)Utils.ByteArrayToObject(redux);
        }

        public async Task<Response<bool>> CreateCharacter(string charName, Guid sessionId)
        {
            var request = new Request<string>{Data = charName, SessionId = sessionId};
            var byteArr = new ByteArrayContent(Utils.ObjectToByteArray(request));
            var response = Client.PostAsync(address + "/createCharacter", byteArr).Result;
            var redux = await response.Content.ReadAsByteArrayAsync();
            return (Response<bool>)Utils.ByteArrayToObject(redux);
        }

        public async Task<Response<bool>> SelectCharacter(Character character, Guid sessionId)
        {
            var request = new Request<Character>{Data = character, SessionId = sessionId};
            var byteArr = new ByteArrayContent(Utils.ObjectToByteArray(request));
            var response = Client.PostAsync(address + "/selectCharacter", byteArr).Result;
            var redux = await response.Content.ReadAsByteArrayAsync();
            return (Response<bool>)Utils.ByteArrayToObject(redux);
        }


        public async Task<Response<Guid>> StartPveMatchmaking(Opponent opponent, Guid sessionId)
        {
            MatchmakeRequest data = new MatchmakeRequest(MatchmakeType.Pve, opponent);
            var request = new Request<MatchmakeRequest> {Data = data, SessionId = sessionId};
            var byteArr = new ByteArrayContent(Utils.ObjectToByteArray(request));
            var response = Client.PostAsync(address + "/matchmake", byteArr).Result;
            var redux = await response.Content.ReadAsByteArrayAsync();
            return (Response<Guid>)Utils.ByteArrayToObject(redux);
        }

        public async Task<Response<Guid>> StartPvpMatchmaking(Guid sessionId)
        {
            MatchmakeRequest data = new MatchmakeRequest(MatchmakeType.Pvp, null);
            var request = new Request<MatchmakeRequest> {Data = data, SessionId = sessionId};
            var byteArr = new ByteArrayContent(Utils.ObjectToByteArray(request));
            var response = Client.PostAsync(address + "/matchmake", byteArr).Result;
            var redux = await response.Content.ReadAsByteArrayAsync();
            return (Response<Guid>)Utils.ByteArrayToObject(redux);
        }

        public async Task<Response<Event>> Poll(Guid sessionId)
        {
            var request = new Request {SessionId = sessionId};
            var byteArr = new ByteArrayContent(Utils.ObjectToByteArray(request));
            var response = Client.PostAsync(address + "/polling", byteArr).Result;
            var redux = await response.Content.ReadAsByteArrayAsync();
            return (Response<Event>) Utils.ByteArrayToObject(redux);
        }

        public async Task<Response<Character>> SetCheatStat(Guid sessionId, Stat stat, int value)
        {
            var cheat = new CheatRequest{Stat = stat, Value = value};
            var request = new Request<CheatRequest>{SessionId = sessionId, Data = cheat };
            var byteArr = new ByteArrayContent(Utils.ObjectToByteArray(request));
            var response = Client.PostAsync(address + "/cheatincrease", byteArr).Result;
            var redux = await response.Content.ReadAsByteArrayAsync();
            return (Response<Character>) Utils.ByteArrayToObject(redux);
        }

        public async Task<Response<int>> Attack(FightMoveCall move, Guid sessionId)
        {
            var request = new Request<FightMoveCall> {Data = move, SessionId = sessionId };
            var byteArr = new ByteArrayContent(Utils.ObjectToByteArray(request));
            var response = Client.PostAsync(address + "/fight-move", byteArr).Result;
            var redux = await response.Content.ReadAsByteArrayAsync();
            return (Response<int>) Utils.ByteArrayToObject(redux);
        }

        public async Task<Response<List<Item>>> GetBackpackItems(int characterId, Guid sessionId)
        {
            var request = new Request<int> { Data = characterId, SessionId = sessionId };
            var byteArr = new ByteArrayContent(Utils.ObjectToByteArray(request));
            var response = Client.PostAsync(address + "/get-items", byteArr).Result;
            var redux = await response.Content.ReadAsByteArrayAsync();
            return (Response<List<Item>>)Utils.ByteArrayToObject(redux);
        }

        public async Task<Response<List<Item>>> GetShopItems(Guid sessionId)
        {
            var request = new Request { SessionId = sessionId };
            var byteArr = new ByteArrayContent(Utils.ObjectToByteArray(request));
            var response = Client.PostAsync(address + "/get-shop-items", byteArr).Result;
            var redux = await response.Content.ReadAsByteArrayAsync();
            return (Response<List<Item>>)Utils.ByteArrayToObject(redux);
        }

        public async Task<Response<bool>> BuyItem(Guid itemId, Guid sessionId)
        {
            var request = new Request<Guid> { Data = itemId, SessionId = sessionId };
            var byteArr = new ByteArrayContent(Utils.ObjectToByteArray(request));
            var response = Client.PostAsync(address + "/buy", byteArr).Result;
            var redux = await response.Content.ReadAsByteArrayAsync();
            return (Response<bool>)Utils.ByteArrayToObject(redux);
        }

        public async Task<Response<bool>> SellItem(Guid itemId, Guid sessionId)
        {
            var request = new Request<Guid> { Data = itemId, SessionId = sessionId };
            var byteArr = new ByteArrayContent(Utils.ObjectToByteArray(request));
            var response = Client.PostAsync(address + "/sell", byteArr).Result;
            var redux = await response.Content.ReadAsByteArrayAsync();
            return (Response<bool>)Utils.ByteArrayToObject(redux);
        }

        public async Task<Response<bool>> EquipItem(Character character, Item item, Guid sessionId)
        {
            CharacterItemDto data = new CharacterItemDto(character, item);
            var request = new Request<CharacterItemDto> { Data = data, SessionId = sessionId };
            var byteArr = new ByteArrayContent(Utils.ObjectToByteArray(request));
            var response = Client.PostAsync(address + "/equip", byteArr).Result;
            var redux = await response.Content.ReadAsByteArrayAsync();
            return (Response<bool>)Utils.ByteArrayToObject(redux);
        }

        public async Task<Response<bool>> UnequipItem(Character character, Item item, Guid sessionId)
        {
            CharacterItemDto data = new CharacterItemDto(character, item);
            var request = new Request<CharacterItemDto> { Data = data, SessionId = sessionId };
            var byteArr = new ByteArrayContent(Utils.ObjectToByteArray(request));
            var response = Client.PostAsync(address + "/unequip", byteArr).Result;
            var redux = await response.Content.ReadAsByteArrayAsync();
            return (Response<bool>)Utils.ByteArrayToObject(redux);
        }

        public async Task<Response<List<Opponent>>> GetPvEHistory(int characterId, Guid sessionId)
        {
            var request = new Request<int> { Data = characterId, SessionId = sessionId };
            var byteArr = new ByteArrayContent(Utils.ObjectToByteArray(request));
            var response = Client.PostAsync(address + "/history", byteArr).Result;
            var redux = await response.Content.ReadAsByteArrayAsync();
            return (Response<List<Opponent>>)Utils.ByteArrayToObject(redux);
        }
    }
}
