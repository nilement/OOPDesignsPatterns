using System;
using Objects.PveOpponent.Opponents;

namespace Objects
{
    [Serializable]
    public class MatchmakeRequest
    {
        public MatchmakeType MatchmakeType;
        public Opponent Opponent;

        public MatchmakeRequest(MatchmakeType _mt, Opponent _op)
        {
            MatchmakeType = _mt;
            Opponent = _op;
        }
    }

    [Serializable]
    public enum MatchmakeType
    {
        Pvp,
        Pve
    }
}