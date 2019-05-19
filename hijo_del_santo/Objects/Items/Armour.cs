using System;

namespace Objects.Items
{
    [Serializable]
    public class Armour : Item
    {

        public Armour()
        {
            var randomInt = Common.Random.Next(Common.Armour.Count);
            var type = Common.Armour[randomInt].Item1;
            Power = Common.Armour[randomInt].Item2;
            BuyPrice = (int) (Power * 20.5 + Common.Random.Next(50, 1147));
            Name = $"{type} of {Modifier.Name}";
            ImageName = $"Armour{randomInt}";
            Category = ItemCategory.Armour;
        }

        public Armour(string name, Guid id, double durability, int buyPrice, string imageName, Modifier modifier, ItemCategory category, int power,
            bool isEquipped) : base(name, id, durability, buyPrice, imageName, modifier, category, power, isEquipped)
        {

        }
    }
}