using System;

namespace Objects.PveOpponent.Opponents
{
    [Serializable]
    public class Knight : Opponent
    {
        public override void Attack()
        {
            Stab();
        }

        private void Stab()
        {
            Console.WriteLine("Stab stab stab #1");
        }

        public Knight() : base(Guid.NewGuid(), AddPrefixToName("Justas Valotka"), Common.Random.Next(5, 150), Common.Random.Next(3, 15), Common.Random.Next(5, 25), 5,
            20, OpponentCategory.Knight)
        {
        }

        public Knight(Guid id, string name, int strength, int agility, int intelligence, int level, int gold, OpponentCategory category,
            int experience = 0) : base(id, name, strength, agility, intelligence, level, gold, category, experience)
        {
        }

        public Knight(Opponent opponent)
        {
            CopyStats(opponent);
        }
    }
}
