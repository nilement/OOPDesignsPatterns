using System;

namespace Objects.Items
{
    [Serializable]

    class Weapon : Item
    {
        public Weapon()
        {
            var randomInt = Common.Random.Next(Common.Weapons.Count);
            var type = Common.Weapons[randomInt].Item1;
            Power = Common.Weapons[randomInt].Item2;
            BuyPrice = (int) (Power * 20.5 + Common.Random.Next(50, 2500));
            Name = $"{type} of {Modifier.Name}";
            ImageName = $"Weapon{randomInt}";
            Category = ItemCategory.Weapon;
        }

        public Weapon(string name, Guid id, double durability, int buyPrice, string imageName, Modifier modifier, ItemCategory category, int power,
            bool isEquipped) : base(name, id, durability, buyPrice, imageName, modifier, category, power, isEquipped)
        {
        }
    }
}