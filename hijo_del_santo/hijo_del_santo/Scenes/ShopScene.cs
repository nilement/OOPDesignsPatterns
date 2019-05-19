using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using hijo_del_santo.Assets;
using Objects.Items;

namespace hijo_del_santo.Scenes
{
    class ShopScene : IScene
    {
        private bool first_frame;

        private List<Item> shop_items;
        private string[] shop_strings;
        private ItemList shop;

        private List<Item> backpack_items;
        private string[] backpack_strings;
        private ItemList backpack;

        private RectButton back;
        private RectButton buy;
        private RectButton sell;

        private TextField gold;
        private TextField error;

        public ShopScene()
        {
            first_frame = true;

            shop_strings = new string[10];
            backpack_strings = new string[10];
            shop = new ItemList(new string[]{ "", "", "", "", "", "", "", "", "", "" },
                   new PointF(Screen.width * 0.3f, Screen.height * 0.45f),
                   new SizeF(Screen.width * 0.35f, Screen.height * 0.7f),
                   10,
                   Color.Gray, Color.White,
                   Color.DarkRed, Color.Red,
                   Color.DarkGreen, Color.PaleGreen,
                   true);

            backpack = new ItemList(new string[]{ "", "", "", "", "", "", "", "", "", "" },
                       new PointF(Screen.width * 0.7f, Screen.height * 0.45f),
                       new SizeF(Screen.width * 0.35f, Screen.height * 0.7f),
                       10,
                       Color.Gray, Color.White,
                       Color.DarkBlue, Color.LightBlue,
                       Color.Orange, Color.Yellow,
                       true);

            back = new RectButton(Color.White, Color.DarkRed,
                   new PointF(Screen.width * 0.15f, Screen.height * 0.9f),
                   new SizeF(Screen.width * 0.2f, Screen.height * 0.1f),
                   "Back", 50);

            buy = new RectButton(Color.White, Color.DarkRed,
                  new PointF(Screen.width * 0.5f, Screen.height * 0.9f),
                  new SizeF(Screen.width * 0.2f, Screen.height * 0.1f),
                  "Buy", 50);

            sell = new RectButton(Color.White, Color.DarkRed,
                   new PointF(Screen.width * 0.85f, Screen.height * 0.9f),
                   new SizeF(Screen.width * 0.2f, Screen.height * 0.1f),
                   "Sell", 50);

            gold = new TextField("Gold: N/A", 40,
                   Screen.Point(0.2f, 0.05f), Color.Gold);

            error = new TextField("", 40,
                    Screen.Point(0.7f, 0.05f), Color.Red);
        }

        public void UpdateGold()
        {
            gold.UpdateText("Gold: " + Screen.character.Gold);
        }

        public void BuyItem(int index)
        {
            int item_price = shop_items[index].BuyPrice;

            var http = new HttpAdapter();
            bool success = http.BuyItem(shop_items[index].Id, Screen.sessionId).Result.Result;

            if(!success)
            {
                if(item_price > Screen.character.Gold)
                {
                    error.UpdateText("Too little gold!");
                }
                else
                {
                    error.UpdateText("Too slow! Item is gone!");
                }
            }
            else
            {
                Screen.character.Gold -= item_price;
            }
        }

        public void SellItem(int index)
        {
            int item_price = backpack_items[index].SellPrice;
            var http = new HttpAdapter();
            bool success = http.SellItem(backpack_items[index].Id, Screen.sessionId).Result.Result;

            if(!success)
            {
                error.UpdateText("Whoops! Something went wrong...");
            }
            else
            {
                Screen.character.Gold += item_price;
            }
        }

        public void GetShopItems()
        {
            var http = new HttpAdapter();
            shop_items = http.GetShopItems(Screen.sessionId).Result.Result;

            for (int i = 0; i < shop_strings.Length; ++i)
            {
                if (i < shop_items.Count)
                {
                    string type = shop_items[i].Category.ToString() + " | ";
                    string name = shop_items[i].Name;
                    string power = " | Pwr: " + shop_items[i].Power;
                    string buy_price = " | $" + shop_items[i].BuyPrice;
                    shop_strings[i] = type + name + power + buy_price;
                }
                else
                {
                    shop_strings[i] = "";
                }
            }
            shop.UpdateItemList(shop_strings);
        }

        public void GetBackpackItems()
        {
            var http = new HttpAdapter();
            backpack_items = http.GetBackpackItems(Screen.character.Id, Screen.sessionId).Result.Result;

            for (int i = 0; i < backpack_strings.Length; ++i)
            {
                if (i < backpack_items.Count)
                {
                    string equipped = backpack_items[i].IsEquipped ? "[E] " : "";
                    string type = backpack_items[i].Category.ToString() + " | ";
                    string name = backpack_items[i].Name;
                    string power = " | Pwr: " + backpack_items[i].Power;
                    string sell_price = " | $" + backpack_items[i].SellPrice;
                    backpack_strings[i] = equipped + type + name + power + sell_price;
                }
                else
                {
                    backpack_strings[i] = "";
                }
            }
            backpack.UpdateItemList(backpack_strings);
        }

        public void HandleMouseInput(MouseInput mouse)
        {
            error.UpdateText("");
            if(back.Contains(mouse.point))
            {
                Screen.scene.SetScene(SceneID.TownHall);
                shop.toggled_index = -1;
                backpack.toggled_index = -1;
                first_frame = true;
            }
            else if(buy.Contains(mouse.point) && shop.toggled_index != -1 && shop.toggled_index < shop_items.Count)
            {
                BuyItem(shop.toggled_index);
                UpdateGold();
                GetShopItems();
                GetBackpackItems();
                shop.toggled_index = -1;
            }
            else if(sell.Contains(mouse.point) && backpack.toggled_index != -1 && backpack.toggled_index < backpack_items.Count)
            {
                SellItem(backpack.toggled_index);
                UpdateGold();
                GetShopItems();
                GetBackpackItems();
                backpack.toggled_index = -1;
            }
            else
            {
                shop.GetClickedIndex(mouse.point);
                backpack.GetClickedIndex(mouse.point);
            }
        }

        public void HandleKeyboardInput(KeyInput key)
        {
        }

        public void Render()
        {
            if(first_frame)
            {
                UpdateGold();
                GetShopItems();
                GetBackpackItems();
                first_frame = false;
            }

            gold.Render();
            error.Render();
            shop.Render();
            backpack.Render();

            back.Render();
            buy.Render();
            sell.Render();
        }
    }
}
