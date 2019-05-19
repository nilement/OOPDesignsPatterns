using System;

namespace Objects.Items
{
    [Serializable]

    class Gloves : Item
    {
        public Gloves()
        {
            var randomInt = Common.Random.Next(Common.Gloves.Count);
            var type = Common.Gloves[randomInt].Item1;
            Power = Common.Gloves[randomInt].Item2;
            BuyPrice = (int) (Power * 20.5 + Common.Random.Next(50, 1147));
            Name = $"{type} of {Modifier.Name}";
            ImageName = $"Gloves{randomInt}";
            Category = ItemCategory.Gloves;
        }

        public Gloves(string name, Guid id, double durability, int buyPrice, string imageName, Modifier modifier, ItemCategory category, int power,
            bool isEquipped) : base(name, id, durability, buyPrice, imageName, modifier, category, power, isEquipped)
        {
        }
    }
}