using System;
using Objects;
using Objects.Events;
using Objects.Iterator;
using Objects.PveDecorator;
using Objects.PveOpponent.Opponents;
using Objects.PveOpponent.PveDecorator;
using Server.Facades.Combat;

namespace Server
{
    public class Matchmaker
    {
        IIterator<CombatRoom> combatRooms;
        IIterator<CombatRoom> pveCombatRooms;
        private object _playerAcceptLock;
        private IEventConnection userEvents;

        public Matchmaker()
        {
            combatRooms = new IterableArray<CombatRoom>();
            pveCombatRooms = new IterableArray<CombatRoom>();
            userEvents = EventHttpAdapter.GetHttpAdapter();
            _playerAcceptLock = new object();
        }

        public Guid AcceptPlayer(Guid sessionId, MatchmakeType type)
        {
            var combatFacade = new CombatFacade();

            var iteratorToUse = type == MatchmakeType.Pvp ? combatRooms : pveCombatRooms;
            lock (_playerAcceptLock)
            {
                userEvents.Subscribe(sessionId);
                var last = iteratorToUse.GetLast();
                if (last == null || !last.IsWaitingForPlayer())
                {
                    var room = new CombatRoom(combatFacade.UpdateCharacter);
                    iteratorToUse.AddAtEnd(room);
                    return room.AddPlayer(sessionId);
                }

                var matchFoundEvent = new MatchFoundEvent {Room = last};
                userEvents.NotifyClient(last.FirstGuid, matchFoundEvent);
                userEvents.NotifyClient(sessionId, matchFoundEvent);
                return last.AddPlayer(sessionId);
            }
        }

        public Guid StartPveFight(Guid sessionId, Opponent historyOpponent = null)
        {
            var combatFacade = new CombatFacade();

            lock (_playerAcceptLock)
            {
                userEvents.Subscribe(sessionId);
                var opponent = historyOpponent == null ? OpponentFactory.CreateOpponent() : OpponentFactory.RestoreOpponent(historyOpponent);
                var room = new CombatRoom(opponent, combatFacade.FinishPveFight);
                pveCombatRooms.AddAtEnd(room);
                var matchFoundEvent = new MatchFoundEvent {Room = room};
                userEvents.NotifyClient(sessionId, matchFoundEvent);
                return room.AddPlayer(sessionId);
            }
        }

        public int DoFightMove(Request<FightMoveCall> data)
        {
            combatRooms.ResetHead();
            CombatRoom room = null;
            MatchmakeType type;

            while (combatRooms.GetCurrent() != null)
            {
                if (combatRooms?.GetCurrent().RoomId == data.Data.RoomId)
                {
                    room = combatRooms.GetCurrent();
                    type = MatchmakeType.Pvp;
                    break;
                }

                combatRooms.Next();
            }

            while (pveCombatRooms.GetCurrent() != null)
            {
                if (pveCombatRooms?.GetCurrent().RoomId == data.Data.RoomId)
                {
                    room = pveCombatRooms.GetCurrent();
                    type = MatchmakeType.Pve;
                    break;
                }

                pveCombatRooms.Next();
            }

            if (room == null)
            {
                return -Int32.MaxValue; // Also known as Matthew's intelligence 
            }

            return room.PlayerTurn(data.Data.FightMove);
        }
    }
}