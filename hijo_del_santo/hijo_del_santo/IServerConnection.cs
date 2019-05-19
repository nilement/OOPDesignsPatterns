using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;
using Objects.Events;
using Objects.PveOpponent.Opponents;

namespace hijo_del_santo
{
    interface IServerConnection
    {
        Task<Response<Guid>> Login(Account content);
        Task<Response<Guid>> Register(Account content);
        Task<Response<List<Character>>> GetAccountCharacters(Guid session);
        Task<Response<bool>> SelectCharacter(Character character, Guid sessionId);
        Task<Response<bool>> CreateCharacter(string charName, Guid session);
        Task<Response<Guid>> StartPveMatchmaking(Opponent opponent, Guid sessionId);
        Task<Response<Guid>> StartPvpMatchmaking(Guid sessionId);
        Task<Response<Event>> Poll(Guid session);
    }
}
