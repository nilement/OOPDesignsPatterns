using System;
using Objects.PveOpponent.Opponents;

namespace Objects.PveOpponent.PveDecorator
{
    [Serializable]
    public class SummonnerOpponent : Opponent
    {

        public SummonnerOpponent(Opponent opponent)
        {
            CopyStats(opponent);
            Combo = opponent.Combo + SummonSkeleton;
            Intelligence *= 2;
            AddSummonerToFlag();
        }

        private void SummonSkeleton()
        {
            Console.WriteLine("Spooky scary skeletons");
        }

        private void AddSummonerToFlag()
        {
            // Change to code and algorithms when more time will be available
            SummonerCount++;
        }
    }
}
