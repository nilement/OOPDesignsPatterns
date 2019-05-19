using System;

namespace Objects.Items
{
    [Serializable]

    class Boots : Item
    {
        public Boots()
        {
            var randomInt = Common.Random.Next(Common.Boots.Count);
            var type = Common.Boots[randomInt].Item1;
            Power = Common.Boots[randomInt].Item2;
            BuyPrice = (int) (Power * 20.5 + Common.Random.Next(50, 1147));
            Name = $"{type} of {Modifier.Name}";
            ImageName = $"Boots{randomInt}";
            Category = ItemCategory.Boots;
        }

        public Boots(string name, Guid id, double durability, int buyPrice, string imageName, Modifier modifier, ItemCategory category, int power,
            bool isEquipped) : base(name, id, durability, buyPrice, imageName, modifier, category, power, isEquipped)
        {
        }
    }
}