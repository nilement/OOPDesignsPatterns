using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using hijo_del_santo.Assets;

namespace hijo_del_santo.Scenes
{
    class PostFightScene : IScene
    {
        private bool first_render;
        private bool show_rewards;

        private TextField result;
        private TextField exp;
        private TextField gold;

        private RectButton accept;

        public PostFightScene()
        {
            first_render = true;
            show_rewards = true;

            result = new TextField("Victory!", 100,
                     Screen.Point(0.5f, 0.25f), Color.Red);

            exp = new TextField("Earned 0 XP", 40,
                  Screen.Point(0.5f, 0.5f), Color.DarkGreen);

            gold = new TextField("Earned 0 Gold", 40,
                   Screen.Point(0.5f, 0.55f), Color.Orange);

            accept = new RectButton(Color.White, Color.DarkRed,
                     Screen.PointF(0.5f, 0.85f),
                     Screen.SizeF(0.2f, 0.1f),
                     "Accept", 70);
        }

        public void UpdateRewards()
        {
            show_rewards = Screen.combat_over_event.IsWinner;
            if(show_rewards)
            {
                result.UpdateText("Victory!");
                exp.UpdateText("Earned " + Screen.combat_over_event.ExpReward + " XP");
                gold.UpdateText("Earned " + Screen.combat_over_event.GoldReward + " Gold");
            }
            else
            {
                result.UpdateText("Defeat...");
            }
        }

        public void HandleMouseInput(MouseInput mouse)
        {
            if(accept.Contains(mouse.point))
            {
                Screen.scene.SetScene(SceneID.TownHall);
                first_render = true;
            }
        }

        public void HandleKeyboardInput(KeyInput key)
        {
        }

        public void Render()
        {
            if(first_render)
            {
                UpdateRewards();
                first_render = false;
            }

            if(show_rewards)
            {
                exp.Render();
                gold.Render();
            }

            result.Render();
            accept.Render();
        }
    }
}
