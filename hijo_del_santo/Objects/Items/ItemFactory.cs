using System;
using Objects.Items;

namespace Objects
{
    public static class ItemFactory
    {
        public static Item GenerateItem(ItemCategory? itemCategory = null)
        {
            switch (itemCategory ?? (ItemCategory)Common.Random.Next(Enum.GetNames(typeof(ItemCategory)).Length))
            {
                case ItemCategory.Armour:
                    return new Armour();
                case ItemCategory.Boots:
                    return new Boots();
                case ItemCategory.Gloves:
                    return new Gloves();
                case ItemCategory.Helmet:
                    return new Helmet();
                case ItemCategory.Pants:
                    return new Pants();
                case ItemCategory.Weapon:
                    return new Weapon();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public static Item CreateItem(Guid id, string name, double durability, int buyPrice, string imageName, int modifierId, int power, ItemCategory itemCategory, bool isEquipped)
        {
            var modifier = new Modifier(modifierId);
            switch (itemCategory)
            {
                case ItemCategory.Armour:
                    return new Armour(name, id, durability, buyPrice, imageName, modifier, itemCategory, power, isEquipped);
                case ItemCategory.Boots:
                    return new Boots(name, id, durability, buyPrice, imageName, modifier, itemCategory, power, isEquipped);
                case ItemCategory.Gloves:
                    return new Gloves(name, id, durability, buyPrice, imageName, modifier, itemCategory, power, isEquipped);
                case ItemCategory.Helmet:
                    return new Helmet(name, id, durability, buyPrice, imageName, modifier, itemCategory, power, isEquipped);
                case ItemCategory.Pants:
                    return new Pants(name, id, durability, buyPrice, imageName, modifier, itemCategory, power, isEquipped);
                case ItemCategory.Weapon:
                    return new Weapon(name, id, durability, buyPrice, imageName, modifier, itemCategory, power, isEquipped);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
    