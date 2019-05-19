using System;

namespace Objects.PveOpponent.Opponents
{
    [Serializable]
    public class Knight3 : Opponent
    {
        public override void Attack()
        {
            Stab();
        }

        private void Stab()
        {
            Console.WriteLine("Stab stab stab #3");

        }
        public Knight3()
        {
            Id = Guid.NewGuid();
            Name = AddPrefixToName("Rytis Pranckūnas");
            Strength = Common.Random.Next(2, 15);
            Agility = Common.Random.Next(5, 30);
            Intelligence = Common.Random.Next(15, 60);
            Level = 5;
            Experience = (Strength + Agility + Intelligence) * 3;
            Category = OpponentCategory.Knight3;
            Gold = Common.Random.Next(20) * (Strength + Agility + Intelligence);
        }

        public Knight3(Guid id, string name, int strength, int agility, int intelligence, int level, int gold, OpponentCategory category, int experience = 0) : base(id, name, strength, agility, intelligence, level, gold, category, experience)
        {
        }

        public Knight3(Opponent opponent)
        {
            CopyStats(opponent);
        }
    }
}
