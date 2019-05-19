using System;

namespace Objects
{
    interface ISessionStore
    {
        bool LoggedIn(Guid sessionId);
        string GetUsername(Guid id);
        Character GetCharacter(Guid id);
        bool SetSessionCharacter(Guid sessionId, Character character);
        Response<Guid> Login(string username);
    }
}