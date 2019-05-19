using System;

namespace Objects.PveOpponent.Opponents
{
    [Serializable]
    public abstract class Opponent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Gold { get; set; }
        public int SummonerCount { get; set; }
        public OpponentCategory Category;

        public delegate void AttackCombo();

        public AttackCombo Combo { get; set; }

        public virtual void Attack()
        {
            Console.WriteLine("attacked");
        }

        protected Opponent()
        {
            Combo = Attack;
        }

        protected Opponent(Guid id, string name, int strength, int agility, int intelligence, int level, int gold, OpponentCategory category,
            int experience = 0)
        {
            Id = id;
            Name = name;
            Strength = strength;
            Agility = agility;
            Intelligence = intelligence;
            Level = level;
            Experience = (Strength + Agility + Intelligence) * 3;
            Gold = Gold = Common.Random.Next(20) * (Strength + Agility + Intelligence);
            Combo = Attack;
            Category = category;
        }

        protected void CopyStats(Opponent opponent)
        {
            Id = opponent.Id;
            Name = opponent.Name;
            Strength = opponent.Strength;
            Agility = opponent.Agility;
            Intelligence = opponent.Intelligence;
            Level = opponent.Level;
            Experience = opponent.Experience;
            Gold = opponent.Gold;
        }

        protected static string AddPrefixToName(string name)
        {
            return Common.AdjectiveList[Common.Random.Next(Common.AdjectiveList.Count - 1)] + $" {name}";
        }
    }
}