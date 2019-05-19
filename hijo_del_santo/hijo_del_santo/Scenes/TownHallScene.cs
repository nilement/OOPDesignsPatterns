using System.Collections.Generic;
using System.Drawing;
using hijo_del_santo.Assets;
using hijo_del_santo.Mediator;
using Objects.PveOpponent.Opponents;

namespace hijo_del_santo.Scenes
{
    class TownHallScene : IScene
    {
        private bool first_frame;

        private TextField text;
        private IColleague pvp;
        private IColleague shop;

        private RectButton pve;
        private RectButton backpack;

        private List<Opponent> opponents;
        private string[] opponent_strings;
        private ItemList pve_history;

        private IInteractionMediator mediator;
        private IColleague pvpWarning;
        private IColleague shopWarning;

        public TownHallScene()
        {
            first_frame = true;

            text = new TextField("Choose your action", 50,
                   new Point(Screen.width / 2, Screen.height / 6),
                   Color.Black);

            pve = new RectButton(Color.White, Color.DarkRed,
                  new PointF(Screen.width / 2.0f, 2.0f * Screen.height / 6.0f),
                  new SizeF(400, 100),
                  "PvE", 70);

            pvp = new ColleagueButton(Color.White, Color.DarkBlue,
                  new PointF(Screen.width / 2.0f, 3.0f * Screen.height / 6.0f),
                  new SizeF(400, 100),
                  "PvP", 70);

            shop = new ColleagueButton(Color.White, Color.DarkGreen,
                   new PointF(Screen.width / 2.0f, 4.0f * Screen.height / 6.0f),
                   new SizeF(400, 100),
                   "Shop", 70);

            backpack = new RectButton(Color.White, Color.Orange,
                       new PointF(Screen.width / 2.0f, 5.0f * Screen.height / 6.0f),
                       new SizeF(400, 100),
                       "Backpack", 70);

            opponent_strings = new string[10];
            pve_history = new ItemList(new string[]{ "", "", "", "", "", "", "", "", "", "" },
                          Screen.PointF(0.85f, 0.35f),
                          Screen.SizeF(0.25f, 0.5f),
                          5, Color.Gray, Color.White, Color.DarkRed, Color.Purple);

            pvpWarning = new Warning(Color.Red, Color.SandyBrown, 
                      new PointF(Screen.width / 2.0f, 3.0f * Screen.height / 6.0f),
                      new SizeF(1000, 600),
                "You have to be at least \nlevel 5 to try PvP", 70);
            shopWarning = new Warning(Color.Red, Color.SandyBrown, 
                new PointF(Screen.width / 2.0f, 3.0f * Screen.height / 6.0f),
                new SizeF(1000, 600),
                "You have to have at least \n10 gold to enter Shop", 70);
            mediator = new InteractionMediator(pvpWarning, pvp, shop, shopWarning);
        }

        public void UpdatePvEHistory()
        {
            var http = new HttpAdapter();
            opponents = http.GetPvEHistory(Screen.character.Id, Screen.sessionId).Result.Result;

            for(int i = 0; i < opponent_strings.Length; ++i)
            {
                if(i < opponents.Count)
                {
                    opponent_strings[i] = opponents[i].Name;
                }
                else
                {
                    opponent_strings[i] = "";
                }
            }
            pve_history.UpdateItemList(opponent_strings);
        }

        public void HandleMouseInput(MouseInput mouse)
        {
            if (((RectButton) pvpWarning).Contains(mouse.point) && ((Warning)pvpWarning).IsEnabled)
            {
                mediator.CloseWarning();
            }
            if (((RectButton) shopWarning).Contains(mouse.point) && ((Warning)shopWarning).IsEnabled)
            {
                mediator.CloseWarning();
            }
            else if(pve.Contains(mouse.point))
            {
                Screen.IsPvpMatchmaking = false;
                Screen.chosen_opponent = null;
                Screen.scene.SetScene(SceneID.Waiting);
                first_frame = true;
            }
            else if(((RectButton)pvp).Contains(mouse.point))
            {
                Screen.IsPvpMatchmaking = true;
                mediator.TryMatchmaking();
            }
            else if(((RectButton)shop).Contains(mouse.point))
            {
                mediator.TryEnterShop();
                first_frame = true;
            }
            else if(backpack.Contains(mouse.point))
            {
                Screen.scene.SetScene(SceneID.Backpack);
                first_frame = true;
            }
            else
            {
                int index = pve_history.GetClickedIndex(mouse.point);
                if (index != -1 && index < opponents.Count)
                {
                    Screen.IsPvpMatchmaking = false;
                    Screen.chosen_opponent = opponents[index];
                    Screen.scene.SetScene(SceneID.Waiting);
                    first_frame = true;
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
                UpdatePvEHistory();
                first_frame = false;
            }

            text.Render();
            pve.Render();
            ((RectButton)pvp).Render();
            ((RectButton)shop).Render();
            backpack.Render();
            pve_history.Render();
            ((RectButton)pvpWarning).Render();
            ((RectButton)shopWarning).Render();
        }
    }
}
