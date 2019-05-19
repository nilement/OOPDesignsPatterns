using System;
using System.Collections.Generic;

namespace Objects
{
    [Serializable]
    public class SessionStore : ISessionStore
    {

        private static SessionStore _sessionStore;
        private static readonly Dictionary<Guid, Tuple<string, Character>> Store = new Dictionary<Guid, Tuple<string, Character>>(3);

        private SessionStore() { }
        private static readonly object LockObj = new object(); 
        public static SessionStore GetSessionStore()  
        {
            lock (LockObj)
            {
                if (_sessionStore != null)
                {
                    return _sessionStore;
                }

                _sessionStore = new SessionStore();
                return _sessionStore;
            }
        }

        public bool LoggedIn(Guid sessionId)
        {
            return Store.ContainsKey(sessionId);
        }

        public string GetUsername(Guid id)
        {
            return Store[id].Item1;
        }

        public Character GetCharacter(Guid id)
        {
            return Store[id].Item2;
        }

        public bool SetSessionCharacter(Guid sessionId, Character character)
        {
            try
            {
                var accountTuple = Store[sessionId];
                var reduxedTuple = new Tuple<string, Character>(accountTuple.Item1, character);
                Store[sessionId] = reduxedTuple;
                return true;
            }
            catch
            {
                return false;
            }

        }

        public Response<Guid> Login(string username)
        {
            var cookie = Guid.NewGuid();
            var tuple = new Tuple<string, Character>(username, null);
            Store.Add(cookie, tuple);
            return Response<Guid>.AddResult(cookie);
        }
    }
}
