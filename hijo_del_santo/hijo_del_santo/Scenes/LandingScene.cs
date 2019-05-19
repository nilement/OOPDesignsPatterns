using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using hijo_del_santo.Assets;

namespace hijo_del_santo.Scenes
{
    class LandingScene : IScene
    {
        private Image splash_screen;
        private RectButton register;
        private RectButton login;

        public LandingScene()
        {
            splash_screen = Image.FromFile("../../images/image3.jpg");
            register = new RectButton(Color.White, Color.DarkBlue,
                       new PointF(5.0f * Screen.width / 16.0f, 11.0f * Screen.height / 16.0f),
                       new SizeF(500, 100),
                       "Register", 90);
            login = new RectButton(Color.White, Color.DarkBlue,
                    new PointF(11.0f * Screen.width / 16.0f, 11.0f * Screen.height / 16.0f),
                    new SizeF(500, 100),
                    "Login", 90);
        }

        public void HandleMouseInput(MouseInput mouse)
        {
            if(register.Contains(mouse.point))
            {
                Screen.scene.SetScene(SceneID.Register);
            }
            else if(login.Contains(mouse.point))
            {
                Screen.scene.SetScene(SceneID.Login);
            }
        }

        public void HandleKeyboardInput(KeyInput key)
        {
        }

        public void Render()
        {
            Screen.graphics.Graphics.DrawImage(splash_screen, Screen.width / 2 - splash_screen.Width / 2, Screen.height / 2 - splash_screen.Height / 2, splash_screen.Width, splash_screen.Height);
            register.Render();
            login.Render();
        }
    }
}
