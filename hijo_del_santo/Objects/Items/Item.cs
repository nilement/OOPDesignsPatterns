using System;

namespace Objects.Items
{
    [Serializable]
    public abstract class Item
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public double Durability { get; set; }
        public int BuyPrice { get; set; }
        public int SellPrice => (int) (BuyPrice * 0.5);
        public string ImageName { get; set; }
        public Modifier Modifier { get; set; }
        public ItemCategory Category { get; set; }
        public int Power { get; set; }
        public bool IsEquipped { get; set; }

        protected Item()
        {
            Id = Guid.NewGuid();
            Durability = Common.Random.Next(5, 85);
            Modifier = new Modifier();
        }

        protected Item(string name, Guid id, double durability, int buyPrice, string imageName, Modifier modifier, ItemCategory category, int power, bool isEquipped)
        {
            Name = name;
            Id = id;
            Durability = durability;
            BuyPrice = buyPrice;
            ImageName = imageName;
            Modifier = modifier;
            Category = category;
            Power = power;
            IsEquipped = isEquipped;
        }
    }
}