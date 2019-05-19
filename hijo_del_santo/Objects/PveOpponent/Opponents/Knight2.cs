using System;

namespace Objects.PveOpponent.Opponents
{
    [Serializable]
    public class Knight2 : Opponent
    {
        public override void Attack()
        {
            Stab();
        }

        private void Stab()
        {
            Console.WriteLine("Stab stab stab #2");
        }

        public Knight2()
        {
            Id = Guid.NewGuid();
            Name = AddPrefixToName("Matas Kulkovas");
            Strength = 5;
            Agility = 5;
            Intelligence = 2;
            Level = 1;
            Experience = 200;
            Category = OpponentCategory.Knight2;
            Gold = Common.Random.Next(20) * (Strength + Agility + Intelligence);
        }
        public Knight2(Opponent opponent)
        {
            CopyStats(opponent);
        }

        public Knight2(Guid id, string name, int strength, int agility, int intelligence, int level, int gold, OpponentCategory category, int experience = 0) : base(id, name, strength, agility, intelligence, level, gold, category, experience)
        {
        }
    }
}
