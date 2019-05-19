using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;
using hijo_del_santo.Assets;

namespace hijo_del_santo
{
    class Console
    {
        public bool toggle;

        public int AlphaValue;
        public ConsoleOutputField output;
        public ConsoleInputField input;

        public ConsoleInterpreter interpreter;

        public Console()
        {
            toggle = false;

            AlphaValue = 150;

            output = new ConsoleOutputField("test",
                     new Point(Screen.width / 2, Screen.height / 6),
                     new Size(Screen.width, Screen.height / 3),
                     5, 20,
                     Color.FromArgb(AlphaValue, 255, 255, 255),
                     Color.FromArgb(AlphaValue, 100, 100, 100));
            input = new ConsoleInputField("",
                    new Point(Screen.width / 2, output.rect_size.Height + Screen.height / 64),
                    new Size(Screen.width, Screen.height / 32),
                    5,
                    Color.FromArgb(AlphaValue, Color.Black),
                    Color.FromArgb(AlphaValue, 150, 150, 150));

            interpreter = new ConsoleInterpreter();
        }

        public void HandleMouseInput(MouseInput mouse)
        {
            if(!output.Contains(mouse.point) && !input.Contains(mouse.point))
            {
                toggle = false;
            }
        }

        public void HandleKeyboardInput(KeyInput key)
        {
            if(key.code == Keys.Enter)
            {
                interpreter.Interpret(output, input.text);
                input.text = "";
            }
            else
            {
                input.UpdateText(key);
            }
        }

        public void Render()
        {
            output.Render();
            input.Render();
        }
    }
}
