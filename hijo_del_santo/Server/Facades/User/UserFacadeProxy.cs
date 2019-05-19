using System;
using System.Collections.Generic;
using Objects;
using Objects.Items;

namespace Server.Facades.User
{
    public class UserFacadeProxy : IUserFacade
    {
        private IUserFacade _userFacade;
        private SessionStore _sessionStore;

        public UserFacadeProxy()
        {
            _userFacade = new UserFacade();
            _sessionStore = SessionStore.GetSessionStore();
        }

        public Response<Guid> Login(Account account)
        {
            return _userFacade.Login(account);
        }

        public Response<Guid> Registration(Account account)
        {
            return _userFacade.Registration(account);
        }

        public Response<List<Character>> GetAccountCharacters(Request accountId)
        {
            if (!_sessionStore.LoggedIn(accountId.SessionId))
            {
                return Response<List<Character>>.ReturnUnauthorized();
            }

            return _userFacade.GetAccountCharacters(accountId);
        }

        public Response<bool> CreateCharacter(Request<string> characterName)
        {
            if (!_sessionStore.LoggedIn(characterName.SessionId))
            {
                return Response<bool>.ReturnUnauthorized();
            }

            return _userFacade.CreateCharacter(characterName);
        }

        public Response<Character> GetCharacter(Request<int> characterId)
        {
            if (!_sessionStore.LoggedIn(characterId.SessionId))
            {
                return Response<Character>.ReturnUnauthorized();
            }

            return _userFacade.GetCharacter(characterId);
        }

        public Response<bool> SelectCharacter(Request<Character> characterRequest)
        {
            if (!_sessionStore.LoggedIn(characterRequest.SessionId))
            {
                return Response<bool>.ReturnUnauthorized();
            }

            return _userFacade.SelectCharacter(characterRequest);
        }

        public Response<List<Item>> GetItems(Request<int> characterId)
        {
            if (!_sessionStore.LoggedIn(characterId.SessionId))
            {
                return Response<List<Item>>.ReturnUnauthorized();
            }

            return _userFacade.GetItems(characterId);
        }

        public Response<bool> EquipItem(Request<CharacterItemDto> characterItemRequest)
        {
            if (!_sessionStore.LoggedIn(characterItemRequest.SessionId))
            {
                return Response<bool>.ReturnUnauthorized();
            }

            return _userFacade.EquipItem(characterItemRequest);
        }

        public Response<bool> UnequipItem(Request<CharacterItemDto> characterItemRequest)
        {
            if (!_sessionStore.LoggedIn(characterItemRequest.SessionId))
            {
                return Response<bool>.ReturnUnauthorized();
            }

            return _userFacade.UnequipItem(characterItemRequest);
        }

        public Response<Character> CheatSetStat(Request<CheatRequest> request)
        {
            if (!_sessionStore.LoggedIn(request.SessionId))
            {
                return Response<Character>.ReturnUnauthorized();
            }

            return _userFacade.CheatSetStat(request);
        }
    }
}
