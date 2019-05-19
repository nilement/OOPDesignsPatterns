using System;

namespace Objects
{
    [Serializable]
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Account()
        {
        }

    }
}
