using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using hijo_del_santo.Properties;
using Objects;

namespace hijo_del_santo.Scenes.TemplateMethod
{
    class RegistrationScene : TemplateScene
    {
        public RegistrationScene() : base()
        {
            confirm_button.UpdateText("Register");
        }

        private bool RegistrationFunction()
        {
            var content = new Account{ Username = username.text, Password = password.text};
            var result = Screen.Server.Register(content).Result;

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
            if(RegistrationFunction())
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
