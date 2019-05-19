using System;
using System.Collections.Generic;
using Objects;
using Objects.Events;
using Objects.PveOpponent.Opponents;
using Server.Facades.Combat;
using Server.Facades.Shop;
using Server.Facades.User;
using Server.Loggers;

namespace Server
{
    public class Router
    {
        private IUserFacade _userFacade;
        private IShopFacade _shopFacade;
        private ICombatFacade _combatFacade;
        private static EventHttpAdapter _httpAdapter;
        private static Matchmaker _matchmaker = new Matchmaker();
        private static Logger _consoleLogger;

        public Router()
        {
            _userFacade = new UserFacadeProxy();
            _shopFacade = new ShopFacadeProxy();
            _combatFacade = new CombatFacade();
            _httpAdapter = EventHttpAdapter.GetHttpAdapter();
            _consoleLogger = ConsoleLogger.GetLogger();
            _consoleLogger.SetNext(FileLogger.GetLogger());
        }

        public object RouteByPath(string path, byte[] data)
        {
            try
            {
                switch (path)
                {
                    case "/login":
                        var loginAccount = (Account) Utils.ByteArrayToObject(data);
                        return _userFacade.Login(loginAccount);
                    case "/register":
                        var registerAccount = (Account) Utils.ByteArrayToObject(data);
                        return _userFacade.Registration(registerAccount);
                    case "/createCharacter":
                        var characterName = (Request<string>) Utils.ByteArrayToObject(data);
                        return _userFacade.CreateCharacter(characterName);
                    case "/characterList":
                        var accountId = (Request) Utils.ByteArrayToObject(data);
                        return _userFacade.GetAccountCharacters(accountId);
                    case "/selectCharacter":
                        var characterRequest = (Request<Character>) Utils.ByteArrayToObject(data);
                        return _userFacade.SelectCharacter(characterRequest);
                    case "/buy":
                        var buyRequest = (Request<Guid>) Utils.ByteArrayToObject(data);
                        return _shopFacade.BuyItem(buyRequest);
                    case "/sell":
                        var sellRequest = (Request<Guid>) Utils.ByteArrayToObject(data);
                        return _shopFacade.SellItem(sellRequest);
                    case "/get-shop-items":
                        var getShopItems = (Request) Utils.ByteArrayToObject(data);
                        return _shopFacade.GetItems(getShopItems);
                    case "/get-items":
                        var getItemsRequest = (Request<int>) Utils.ByteArrayToObject(data);
                        return _userFacade.GetItems(getItemsRequest);
                    case "/matchmake":
                        var matchmakeRequest = (Request<MatchmakeRequest>) Utils.ByteArrayToObject(data);
                        return Response<Guid>.AddResult(matchmakeRequest.Data.MatchmakeType == MatchmakeType.Pvp
                            ? _matchmaker.AcceptPlayer(matchmakeRequest.SessionId, matchmakeRequest.Data.MatchmakeType)
                            : _matchmaker.StartPveFight(matchmakeRequest.SessionId, matchmakeRequest.Data.Opponent));
                    case "/polling":
                        var pollingRequest = (Request) Utils.ByteArrayToObject(data);
                        return Response<Event>.AddResult(_httpAdapter.LatestEvent(pollingRequest.SessionId));
                    case "/equip":
                        var equipRequest = (Request<CharacterItemDto>)Utils.ByteArrayToObject(data);
                        return _userFacade.EquipItem(equipRequest);
                    case "/unequip":
                        var unequipRequest = (Request<CharacterItemDto>)Utils.ByteArrayToObject(data);
                        return _userFacade.UnequipItem(unequipRequest);
                    case "/cheatincrease":
                        var cheatRequest = (Request<CheatRequest>) Utils.ByteArrayToObject(data);
                        return _userFacade.CheatSetStat(cheatRequest);
                    case "/fight-move":
                        var moveRequest = (Request<FightMoveCall>) Utils.ByteArrayToObject(data);
                        return new Response<int> { Result = _matchmaker.DoFightMove(moveRequest) } ;
                    case "/history":
                        var characterHistoryRequest = (Request<int>)Utils.ByteArrayToObject(data);
                        return new Response<List<Opponent>> { Result = _combatFacade.GetHistory(characterHistoryRequest) };
                    default:
                        return Response<string>.ReturnNotFound();
                }
                //
                //PlayerTurn
            }
            catch (Exception ex)
            {
                _consoleLogger.Message(ex.Message, LogType.All);
                return Response<string>.ReturnInternalServerError(ex.ToString());
            }
        }
    }
}