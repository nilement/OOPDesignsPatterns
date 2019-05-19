using System;
using System.Collections.Generic;

namespace Objects
{
    public static class Common
    {
        public static Random Random = new Random(2);

        public static readonly List<Tuple<string, double>> Modifiers =
            new List<Tuple<string, double>>
            {
                new Tuple<string, double>("Piktas", 21),
                new Tuple<string, double>("breb", 7),
                new Tuple<string, double>("garb", 10),
                new Tuple<string, double>("quicksliver", 25),
                new Tuple<string, double>("bab", 4)
            };

        public static readonly List<Tuple<string, int>> Weapons =
            new List<Tuple<string, int>>
            {
                new Tuple<string, int>("Sword", 8),
                new Tuple<string, int>("Dagger", 6)
            };

        public static readonly List<Tuple<string, int>> Pants =
            new List<Tuple<string, int>>
            {
                new Tuple<string, int>("Pants", 7),
                new Tuple<string, int>("Skirt", 89)
            };

        public static readonly List<Tuple<string, int>> Helmets =
            new List<Tuple<string, int>>
            {
                new Tuple<string, int>("Full", 8),
                new Tuple<string, int>("Medium", 6)
            };

        public static readonly List<Tuple<string, int>> Gloves =
            new List<Tuple<string, int>>
            {
                new Tuple<string, int>("Leather", 8),
                new Tuple<string, int>("Latex", 6)
            };

        public static readonly List<Tuple<string, int>> Boots =
            new List<Tuple<string, int>>
            {
                new Tuple<string, int>("Leather", 8),
                new Tuple<string, int>("Latex", 6)
            };

        public static readonly List<Tuple<string, int>> Armour =
            new List<Tuple<string, int>>
            {
                new Tuple<string, int>("Rune", 8),
                new Tuple<string, int>("Latex", 6)
            };

        public static readonly List<string> AdjectiveList = new List<string>
        {
            "ashy",
            "black",
            "blue",
            "gray",
            "green",
            "icy",
            "lemon",
            "mango",
            "orange",
            "purple",
            "red",
            "salmon",
            "white",
            "yellow",
            "attractive",
            "bald",
            "beautiful",
            "chubby",
            "clean",
            "dazzling",
            "drab",
            "elegant",
            "fancy",
            "fit",
            "flabby",
            "glamorous",
            "gorgeous",
            "handsome",
            "long",
            "magnificen",
            "muscular",
            "plain",
            "plump",
            "quaint",
            "scruffy",
            "shapely",
            "short",
            "skinny",
            "stocky",
            "ugly",
            "unkempt",
            "unsightly"
        };
    }

    [Serializable]
    public enum Stat
    {
        None = 0,
        Strength,
        Agility,
        Intelligence,
        All,

        Count,
    }

    [Serializable]
    public class CheatRequest
    {
        public Stat Stat;
        public int Value;
    }
}