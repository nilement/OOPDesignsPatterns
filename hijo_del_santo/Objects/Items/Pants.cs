using System;

namespace Objects.Items
{
    [Serializable]

    class Pants : Item
    {
        public Pants()
        {
            var randomInt = Common.Random.Next(Common.Pants.Count);
            var type = Common.Pants[randomInt].Item1;
            Power = Common.Pants[randomInt].Item2;
            BuyPrice = (int) (Power * 20.5 + Common.Random.Next(50, 1147));
            Name = $"{type} of {Modifier.Name}";
            ImageName = $"Pants{randomInt}";
            Category = ItemCategory.Pants;
        }

        public Pants(string name, Guid id, double durability, int buyPrice, string imageName, Modifier modifier, ItemCategory category, int power,
            bool isEquipped) : base(name, id, durability, buyPrice, imageName, modifier, category, power, isEquipped)
        {
        }
    }
}