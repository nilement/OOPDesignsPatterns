using System;
using System.Collections.Generic;
using System.Linq;
using Objects.Items;
using Objects.Strategy;

namespace Objects
{
    public class Shop
    {
        public List<Item> Items { get; }

        private static Shop _shop;
        private const int NumberOfItems = 10;
        public static ISaleStrategy _saleStrategy;

        private static readonly object LockObj = new object();
        public static Shop GetShop()
        {
            lock (LockObj)
            {
                if (_shop != null)
                {
                    SetSaleStrategy();
                    return _shop;
                }

                _shop = new Shop();
                return _shop;
            }
        }

        public Item BuyItem(Guid itemId)
        {
            var item = Items.FirstOrDefault(x => x.Id == itemId);
            Items.Remove(item);
            AddItem();
            return item;
        }

        private Shop()
        {
            SetSaleStrategy();
            Items = new List<Item>();
            for (var i = 0; i < NumberOfItems; i++)
            {
                AddItem();
            }
        }

        public void AddItem()
        {
            var item = ItemFactory.GenerateItem();
            item.BuyPrice = _saleStrategy.GetPrice(item.BuyPrice);
            Items.Add(item);
        }

        public static void SetSaleStrategy(int nowHour = -1)
        {
            var now = DateTime.Now.Hour;
            if (nowHour >= 0)
            {
                now = nowHour;
            }

            if (now < 4 || now >= 20)
            {
                _saleStrategy = new NightSaleStrategy();
            }
            else if (now <= 12)
            {
                _saleStrategy = new MorningSaleStrategy();
            }
            else
            {
                _saleStrategy = new AfternoonSaleStrategy();
            }

        }
    }
}
