using System;

namespace Objects.Events
{
    public interface IEventConnection
    {
        void Subscribe(Guid userGuid);
        void NotifyClient(Guid userGuid, Event ev);
        void Unsubscribe(Guid userGuid);
    }
}
