using System;
using System.Collections.Generic;
using Objects;
using Objects.Items;

namespace Server.Facades.User
{
    interface IUserFacade
    {
        Response<Guid> Login(Account account);
        Response<Guid> Registration(Account account);
        Response<List<Character>> GetAccountCharacters(Request accountId);
        Response<bool> CreateCharacter(Request<string> characterName);
        Response<Character> GetCharacter(Request<int> characterId);
        Response<bool> SelectCharacter(Request<Character> characterRequest);
        Response<List<Item>> GetItems(Request<int> characterId);
        Response<bool> EquipItem(Request<CharacterItemDto> characterItemRequest);
        Response<bool> UnequipItem(Request<CharacterItemDto> characterItemRequest);
        Response<Character> CheatSetStat(Request<CheatRequest> request);
    }
}
