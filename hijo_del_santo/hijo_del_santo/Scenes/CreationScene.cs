using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using hijo_del_santo.Assets;
using Objects;

namespace hijo_del_santo.Scenes
{
    class CreationScene : IScene
    {
        private TextField text;
        private InputField name;
        private RectButton back;
        private RectButton next;

        public CreationScene()
        {
            text = new TextField("Enter your character name", 50,
                   new Point(Screen.width / 2, Screen.height / 6),
                   Color.Black);

            name = new InputField("", false,
                   new Point(Screen.width / 2, 3 * Screen.height / 6),
                   new Size(500, 50),
                   5, Color.Black, Color.Black, Color.Black);

            back = new RectButton(Color.White, Color.DarkRed,
                   new PointF(Screen.width / 4.0f, 5.0f * Screen.height / 6.0f),
                   new SizeF(300, 100),
                   "Back", 50);

            next = new RectButton(Color.White, Color.DarkGreen,
                   new PointF(3.0f * Screen.width / 4.0f, 5.0f * Screen.height / 6.0f),
                   new SizeF(300, 100),
                   "Next", 50);
        }

        
        private bool CreateCharacter()
        {
            // TODO(rytis): Create character here
            return Screen.Server.CreateCharacter(name.text, Screen.sessionId).Result.Result;
        }
        

        public void HandleMouseInput(MouseInput mouse)
        {
            if(next.Contains(mouse.point))
            {
                var success = CreateCharacter();
                if(success)
                {
                    Screen.scene.SetScene(SceneID.Selection);
                    name.text = "";
                }
            }
            else if(back.Contains(mouse.point))
            {
                Screen.scene.SetScene(SceneID.Selection);
                name.text = "";
            }
        }

        public void HandleKeyboardInput(KeyInput key)
        {
            if(key.code == Keys.Enter)
            {
            }
            else
            {
                name.UpdateText(key);
            }
        }

        public void Render()
        {
            text.Render();
            name.Render();
            back.Render();
            next.Render();
        }
    }
}
