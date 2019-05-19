using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;
using hijo_del_santo.Scenes;
using Objects;
using Objects.PveOpponent.Opponents;

namespace hijo_del_santo
{
    class Screen
    {
        public const int width = 1920;
        public const int height = 1080;
        public static bool IsPvpMatchmaking;
        public static BufferedGraphics graphics;
        public static Console console;
        public static SceneController scene;
        public static IServerConnection Server = new HttpAdapter();
        public static Guid sessionId;
        public static Character character;
        public static Opponent chosen_opponent;
        public static CombatRoom room;
        public static Objects.Events.CombatOverEvent combat_over_event;

        public static PointF PointF(float X, float Y)
        {
            return new PointF(width * X, height * Y);
        }

        public static Point Point(float X, float Y)
        {
            return new Point((int)(width * X), (int)(height * Y));
        }

        public static SizeF SizeF(float X, float Y)
        {
            return new SizeF(width * X, height * Y);
        }

        public static Size Size(float X, float Y)
        {
            return new Size((int)(width * X), (int)(height * Y));
        }
    }

    class MouseInput
    {
        public Point point;
    }

    class KeyInput
    {
        public char character;
        public Keys code;
        public Keys modifier;
    }

    class Input
    {
        public static MouseInput mouse = new MouseInput();
        public static KeyInput key = new KeyInput();
    }

    class GameWindow : Form
    {
        private BufferedGraphicsContext context;
        private Timer timer;

        public GameWindow()
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;

            this.MouseClick += MouseEventClick;
            this.KeyDown += KeyEventDown;
            this.KeyPress += KeyEventPress;
            this.Size = new Size(Screen.width, Screen.height);
            this.FormBorderStyle = FormBorderStyle.None;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);

            timer = new Timer();
            timer.Interval = 16;
            timer.Tick += TimerTick;

            Input.mouse.point = new Point();

            context = BufferedGraphicsManager.Current;
            context.MaximumBuffer = new Size(Screen.width + 1, Screen.height + 1);
            Screen.graphics = context.Allocate(this.CreateGraphics(), new Rectangle(0, 0, Screen.width, Screen.height));

            Screen.console = new Console();
            Screen.scene = new SceneController();

            ResetBuffer();
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            Screen.scene.Render();
            if(Screen.console.toggle)
            {
                Screen.console.Render();
            }
            this.Refresh();
            ResetBuffer();
        }

        private void MouseEventClick(object sender, MouseEventArgs e)
        {
            Input.mouse.point.X = e.X;
            Input.mouse.point.Y = e.Y;
            if(Screen.console.toggle)
            {
                Screen.console.HandleMouseInput(Input.mouse);
            }
            else
            {
                Screen.scene.HandleMouseInput(Input.mouse);
            }
        }

        private void KeyEventDown(object sender, KeyEventArgs e)
        {
            Input.key.code = e.KeyCode;
            Input.key.modifier = e.Modifiers;
        }

        private void KeyEventPress(object sender, KeyPressEventArgs e)
        {
            Input.key.character = e.KeyChar;
            if(Input.key.code == Keys.Oemtilde)
            {
                Screen.console.toggle = !Screen.console.toggle;
            }
            else
            {
                if(Screen.console.toggle)
                {
                    Screen.console.HandleKeyboardInput(Input.key);
                }
                else
                {
                    Screen.scene.HandleKeyboardInput(Input.key);
                }
            }
        }

        public void ResetBuffer()
        {
            Screen.graphics.Graphics.FillRectangle(Brushes.White, 0, 0, Screen.width, Screen.height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Screen.graphics.Render(e.Graphics);
        }
    }
}
