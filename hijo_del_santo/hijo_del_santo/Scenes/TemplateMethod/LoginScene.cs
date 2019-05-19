using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Media;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Drawing;
using hijo_del_santo.Assets;
using hijo_del_santo.Properties;
using hijo_del_santo.Scenes.TemplateMethod;
using Objects;

namespace hijo_del_santo.Scenes
{

    class LoginScene : TemplateScene
    {
        public LoginScene() : base()
        {
            confirm_button.UpdateText("Login");
        }

        private bool LoginFunction()
        {
            var content = new Account {Password = password.text, Username = username.text};
            var result = Screen.Server.Login(content).Result;

            if (result.ResponseCode == HttpStatusCode.OK)
            {
                Screen.sessionId = result.Result;
                return true;
            }

            error_message = result.ResponseMessage;
            return false;
        }

        protected override void ConfirmationDispatcher()
        {
            if(LoginFunction())
            {
                new SoundPlayer(Resources.Gold1).Play();
                Screen.scene.SetScene(SceneID.Selection);
            }

            username.text = "";
            password.text = "";
            password.masked_text = "";
        }
    }
}
