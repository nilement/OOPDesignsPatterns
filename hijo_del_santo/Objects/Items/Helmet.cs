using System;

namespace Objects.Items
{
    [Serializable]

    class Helmet : Item
    {
        public Helmet()
        {
            var randomInt = Common.Random.Next(Common.Helmets.Count);
            var type = Common.Helmets[randomInt].Item1;
            Power = Common.Helmets[randomInt].Item2;
            ImageName = $"Helmet{randomInt}";
            BuyPrice = (int) (Power * 20.5 + Common.Random.Next(50, 1147));
            Name = $"{type} of {Modifier.Name}";
            Category = ItemCategory.Helmet;
        }

        public Helmet(string name, Guid id, double durability, int buyPrice, string imageName, Modifier modifier, ItemCategory category, int power,
            bool isEquipped) : base(name, id, durability, buyPrice, imageName, modifier, category, power, isEquipped)
        {
        }
    }
}