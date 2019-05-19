
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NUnit.Framework;
using Objects;
using Objects.PveOpponent.Opponents;
using Objects.PveOpponent.PveDecorator;

namespace Server.Facades.Combat
{
    interface ICombatFacade
    {
        void WriteToHistory(Opponent opponent, int characterId);
        void UpdateCharacter(Opponent opponent, int characterId, bool hasWon);
        void FinishPveFight(Opponent opponent, int characterId, bool hasWon);
        List<Opponent> GetHistory(Request<int> characterId);
    }
}
