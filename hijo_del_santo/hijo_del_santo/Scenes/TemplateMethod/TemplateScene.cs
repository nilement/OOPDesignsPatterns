using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hijo_del_santo.Assets;
using hijo_del_santo.Properties;
using Objects;

namespace hijo_del_santo.Scenes.TemplateMethod
{
    enum FocusTarget
    {
        NoTarget = 0,
        Username,
        Password,

        Count,
    }

    abstract class TemplateScene : IScene
    {
        protected InputField username;
        protected InputField password;
        protected FocusTarget focus;

        protected string error_message = "";
        protected TextField error_field;
        
        protected RectButton confirm_button;
        protected RectButton back_button;


        protected TemplateScene()
        {
            Point error_point = new Point(Screen.width / 2, Screen.height / 8);
            error_field = new TextField(error_message, 30, error_point, Color.Red);

            Point username_point = new Point(Screen.width / 2, Screen.height / 2 - 100);
            Size username_size = new Size(700, 40);
            Point password_point = new Point(Screen.width / 2, Screen.height / 2 + 100);
            Size password_size = new Size(700, 40);

            username = new InputField("aaa", false, username_point, username_size, 5, Color.Black, Color.Black, Color.Red);
            password = new InputField("aaa", true, password_point, password_size, 5, Color.Black, Color.Black, Color.Red);

            PointF confirm_point = new PointF(11.0f * Screen.width / 16.0f, 13.0f * Screen.height / 16.0f);
            SizeF confirm_size = new SizeF(400, 100);
            PointF back_point = new PointF(5.0f * Screen.width / 16.0f, 13.0f * Screen.height / 16.0f);
            SizeF back_size = new SizeF(400, 100);

            confirm_button = new RectButton(Color.White, Color.DarkRed, confirm_point, confirm_size, "", 60);
            back_button = new RectButton(Color.White, Color.DarkBlue, back_point, back_size, "Back", 60);
        }

        protected abstract void ConfirmationDispatcher();

        public void HandleMouseInput(MouseInput mouse)
        {
            if(username.Contains(mouse.point))
            {
                focus = FocusTarget.Username;
                username.text = "";
            }
            else if(password.Contains(mouse.point))
            {
                focus = FocusTarget.Password;
                password.text = "";
                password.masked_text = "";
            }
            else if(confirm_button.Contains(mouse.point))
            {
                ConfirmationDispatcher();
                focus = FocusTarget.NoTarget;
            }
            else if(back_button.Contains(mouse.point))
            {
                Screen.scene.SetScene(SceneID.Landing);
                username.text = "";
                password.text = "";
                password.masked_text = "";
                focus = FocusTarget.NoTarget;
            }
            else
            {
                focus = FocusTarget.NoTarget;
            }
        }

        public void HandleKeyboardInput(KeyInput key)
        {
            if(key.code == Keys.Tab)
            {
                if(key.modifier != Keys.Shift)
                {
                    ++focus;
                    if(focus == FocusTarget.Count)
                    {
                        focus = 0;
                    }
                }
                else
                {
                    --focus;
                    if(focus < FocusTarget.NoTarget)
                    {
                        focus = FocusTarget.Count - 1;
                    }
                }
            }
            else if(key.code == Keys.Escape)
            {
                focus = FocusTarget.NoTarget;
            }
            else if(key.code == Keys.Enter)
            {
                ConfirmationDispatcher();
            }
            else
            {
                switch(focus)
                {
                    default:
                    {
                    } break;
                    case FocusTarget.Username:
                    {
                        username.UpdateText(key);
                    } break;
                    case FocusTarget.Password:
                    {
                        password.UpdateText(key);
                    } break;
                }
            }
        }

        public void Render()
        {
            error_field.UpdateText(error_message);
            error_field.Render();

            switch(focus)
            {
                default:
                {
                } break;
                case FocusTarget.Username:
                {
                    username.Render(true);
                    password.Render(false);
                } break;
                case FocusTarget.Password:
                {
                    username.Render(false);
                    password.Render(true);
                } break;
                case FocusTarget.NoTarget:
                {
                    username.Render(false);
                    password.Render(false);
                } break;
            }

            back_button.Render();
            confirm_button.Render();
        }
    }
}
