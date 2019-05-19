using System;
using System.Collections.Generic;

namespace Objects.Events
{
    [Serializable]
    public class EventHttpAdapter : IEventConnection
    {
        private readonly Dictionary<Guid, Queue<Event>> _queueMap;
        private static EventHttpAdapter _eventHttpAdapter;
        private static object _lockObj = new object();

        public static EventHttpAdapter GetHttpAdapter()
        {
            lock (_lockObj)
            {
                if (_eventHttpAdapter == null)
                {
                    _eventHttpAdapter = new EventHttpAdapter();
                    return _eventHttpAdapter;
                }

                return _eventHttpAdapter;
            }
        }
        public EventHttpAdapter()
        {
            _queueMap = new Dictionary<Guid, Queue<Event>>();
        }

        public void Subscribe(Guid userGuid)
        {
            _queueMap[userGuid] = new Queue<Event>();
        }

        public void Unsubscribe(Guid userGuid)
        {
            _queueMap[userGuid] = null;
        }

        public void NotifyClient(Guid userGuid, Event ev)
        {
            _queueMap[userGuid].Enqueue(ev);
        }

        public Event LatestEvent(Guid userGuid)
        {
            if (_queueMap[userGuid]?.Count == 0)
            {
                return new NullEvent();
            } 

            return _queueMap[userGuid].Dequeue();
        }
    }

    [Serializable]
    public class Event
    {
        public EventType type;
    }

    [Serializable]
    public class MatchFoundEvent : Event
    {
        public MatchFoundEvent()
        {
            type = EventType.Matchfound;
        }

        public CombatRoom Room;
    }

    [Serializable]
    public class CombatEvent : Event
    {
        public bool TargetIsFirst;
        public ActionType Type;
        public int Health;

        public CombatEvent()
        {
        }

        public CombatEvent(bool isFirstTurn, ActionType type, int health)
        {
            TargetIsFirst = !isFirstTurn;
            Type = type;
            Health = health;
            this.type = EventType.CombatEvent;
        }
    }

    [Serializable]
    public class CombatOverEvent : Event
    {
        public CombatOverEvent()
        {
            this.type = EventType.CombatOverEvent;
        }

        public CombatOverEvent(bool isWinner, int goldReward, int expReward) : this()
        {
            IsWinner = isWinner;
            GoldReward = goldReward;
            ExpReward = expReward;
        } 

        public bool IsWinner;
        public int GoldReward, ExpReward;
    }

    [Serializable]
    public class NullEvent : Event
    {
        public NullEvent()
        {
            type = EventType.NullEvent;
        }
    }

    public enum EventType
    {
        Matchfound,
        NullEvent,
        CombatEvent,
        CombatOverEvent
    }
}