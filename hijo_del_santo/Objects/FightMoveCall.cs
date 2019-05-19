using System;

namespace Objects
{
    [Serializable]
    public class FightMoveCall
    {
        public Guid RoomId;
        public ActionType FightMove;
    }

    [Serializable]
    public enum ActionType
    {
        Attack
    }
}
