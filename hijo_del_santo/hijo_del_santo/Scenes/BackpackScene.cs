using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Text;
using hijo_del_santo.Assets;
using Objects.Items;

namespace hijo_del_santo.Scenes
{
    class BackpackScene : IScene
    {
        private bool first_frame;

        private List<Item> backpack_items;
        private string[] backpack_strings;
        private ItemList backpack;

        private bool is_equip;

        private RectButton equip;
        private RectButton back;

        private int item_power;

        private TextField stats;
        private TextField strength;
        private TextField agility;
        private TextField intelligence;
        private TextField item_power_text;

        private TextField error;

        public BackpackScene()
        {
            first_frame = true;

            backpack_strings = new string[10];
            backpack = new ItemList(new string[]{ "", "", "", "", "", "", "", "", "", "" },
                       Screen.PointF(0.5f, 0.45f),
                       Screen.SizeF(0.4f, 0.7f),
                       10,
                       Color.Gray, Color.White,
                       Color.DarkBlue, Color.LightBlue,
                       Color.Orange, Color.Yellow,
                       true);

            is_equip = true;

            equip = new RectButton(Color.White, Color.DarkGreen,
                    Screen.PointF(0.65f, 0.9f),
                    Screen.SizeF(0.15f, 0.1f),
                    "Equip", 50);

            back = new RectButton(Color.White, Color.DarkRed,
                   Screen.PointF(0.35f, 0.9f),
                   Screen.SizeF(0.15f, 0.1f),
                   "Back", 50);

            stats = new TextField("Stats", 40,
                    Screen.Point(0.85f, 0.1f), Color.Black);

            strength = new TextField("0 Strength", 30,
                       Screen.Point(0.85f, 0.15f), Color.Black);

            agility = new TextField("0 Agility", 30,
                      Screen.Point(0.85f, 0.2f), Color.Black);

            intelligence = new TextField("0 Intelligence", 30,
                           Screen.Point(0.85f, 0.25f), Color.Black);

            item_power_text = new TextField("0 Total Item Power", 30,
                              Screen.Point(0.85f, 0.35f), Color.Black);

            error = new TextField("", 40,
                    Screen.Point(0.85f, 0.6f), Color.Black);
        }

        public void GetBackpackItems()
        {
            var http = new HttpAdapter();
            backpack_items = http.GetBackpackItems(Screen.character.Id, Screen.sessionId).Result.Result;

            for(int i = 0; i < backpack_strings.Length; ++i)
            {
                if(i < backpack_items.Count)
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

        public void UpdateStats()
        {
            strength.UpdateText(Screen.character.Strength + " Strength");
            agility.UpdateText(Screen.character.Agility + " Agility");
            intelligence.UpdateText(Screen.character.Intelligence + " Intelligence");

            item_power = 0;
            for(int i = 0; i < backpack_items.Count; ++i)
            {
                if(backpack_items[i].IsEquipped)
                {
                    item_power += backpack_items[i].Power;
                }
            }

            item_power_text.UpdateText(item_power + " Total Item Power");
        }

        public void EquipItem(int index)
        {
            var http = new HttpAdapter();
            bool success = http.EquipItem(Screen.character, backpack_items[index], Screen.sessionId).Result.Result;

            if(!success)
            {
                error.UpdateText("Could not equip the item!");
            }
            else
            {
                is_equip = !is_equip;
                equip.UpdateText("Unequip");
            }
        }

        public void UnequipItem(int index)
        {
            var http = new HttpAdapter();
            bool success = http.UnequipItem(Screen.character, backpack_items[index], Screen.sessionId).Result.Result;

            if(!success)
            {
                error.UpdateText("Could not unequip the item!");
            }
            else
            {
                is_equip = !is_equip;
                equip.UpdateText("Equip");
            }
        }

        public void HandleMouseInput(MouseInput mouse)
        {
            error.UpdateText("");
            if(back.Contains(mouse.point))
            {
                Screen.scene.SetScene(SceneID.TownHall);
                backpack.toggled_index = -1;
                first_frame = true;
            }
            else if(equip.Contains(mouse.point))
            {
                if(backpack.toggled_index != -1 && backpack.toggled_index < backpack_items.Count)
                {
                    if(is_equip)
                    {
                        EquipItem(backpack.toggled_index);
                    }
                    else
                    {
                        UnequipItem(backpack.toggled_index);
                    }
                    first_frame = true;
                }
            }
            else
            {
                int toggled_index = backpack.GetClickedIndex(mouse.point);
                if(toggled_index != -1 && toggled_index < backpack_items.Count && backpack_items[toggled_index].IsEquipped)
                {
                    is_equip = false;
                    equip.UpdateText("Unequip");
                }
                else
                {
                    is_equip = true;
                    equip.UpdateText("Equip");
                }
            }
        }

        public void HandleKeyboardInput(KeyInput key)
        {
        }

        public void Render()
        {
            if(first_frame)
            {
                GetBackpackItems();
                UpdateStats();
                first_frame = false;
            }

            backpack.Render();
            equip.Render();
            back.Render();
            stats.Render();
            strength.Render();
            agility.Render();
            intelligence.Render();
            item_power_text.Render();
            error.Render();
        }
    }
}
