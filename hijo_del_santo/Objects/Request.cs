using System;

namespace Objects
{
    [Serializable]
    public class Request<T>
    {
        public T Data { get; set; }
        public Guid SessionId { get; set; }
    }

    [Serializable]
    public class Request
    {
        public Guid SessionId { get; set; }
    }
}
