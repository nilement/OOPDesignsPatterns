
using System;
using System.Collections.Generic;
using Objects.Items;

namespace Objects
{
    [Serializable]
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Gold { get; set; }
        public List<Item> Items { get; set; }
         
        public Character(string name, int strength = 5, int agility = 5, int intelligence = 5, int level = 0, int experience = 0, int gold = 500)
        {
            Name = name;
            Strength = strength;
            Agility = agility;
            Intelligence = intelligence;
            Level = level;
            Experience = experience;
            Gold = gold;
        }

        public Character(int id, string name, int strength, int agility, int intelligence, int level, int experience, int gold)
        {
            Id = id;
            Name = name;
            Strength = strength;
            Agility = agility;
            Intelligence = intelligence;
            Level = level;
            Experience = experience;
            Gold = gold;
        }
    }
}
