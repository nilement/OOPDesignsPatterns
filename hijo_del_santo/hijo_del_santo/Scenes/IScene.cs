using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hijo_del_santo.Scenes
{
    interface IScene
    {
        void HandleMouseInput(MouseInput mouse);
        void HandleKeyboardInput(KeyInput key);
        void Render();
    }
}
