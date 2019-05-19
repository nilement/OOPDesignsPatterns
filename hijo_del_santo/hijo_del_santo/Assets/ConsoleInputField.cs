using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;

namespace hijo_del_santo.Assets
{
    class ConsoleInputField
    {
        public Point center;
        public int offset;

        public int font_size;
        public Font font;

        public string text;
        public Point text_draw_point;

        public SolidBrush text_brush;
        public SolidBrush rect_brush;

        public Size rect_size;
        public Point rect_draw_point;
        public Rectangle rect;

        public ConsoleInputField() : this("Default", new Point(Screen.width / 2, Screen.height / 2), new Size(400, 400), 5, Color.Black, Color.Gray)
        {
        }

        public ConsoleInputField(string _text, Point _center, Size _rect_size, int _offset, Color _text_color, Color _rect_color)
        {
            text = _text;

            center = _center;
            rect_size = _rect_size;
            offset = _offset;

            UpdateFont();

            text_brush = new SolidBrush(_text_color);
            rect_brush = new SolidBrush(_rect_color);

            rect_draw_point = new Point(0, 0);
            text_draw_point = new Point(0, 0);
            UpdateDrawPoints();
            rect = new Rectangle(rect_draw_point, rect_size);
        }

        public void UpdateFont()
        {
            font_size = rect_size.Height - 2 * offset;
            font = new Font(new FontFamily(GenericFontFamilies.Monospace), font_size, GraphicsUnit.Pixel);
        }

        public void UpdateDrawPoints()
        {
            rect_draw_point.X = center.X - rect_size.Width / 2;
            rect_draw_point.Y = center.Y - rect_size.Height / 2;

            text_draw_point.X = rect_draw_point.X + offset;
            text_draw_point.Y = rect_draw_point.Y + offset;
        }

        public bool Contains(Point point)
        {
            return rect.Contains(point);
        }

        public void UpdateText(KeyInput key)
        {
            switch(key.code)
            {
                default:
                {
                    switch(key.modifier)
                    {
                        case Keys.Shift:
                        default:
                        {
                            if(text.Length < 64)
                            {
                                text += key.character;
                            }
                        } break;
                        case Keys.Alt:
                        {
                        } break;
                        case Keys.Control:
                        {
                        } break;
                    }
                } break;
                case Keys.Back:
                {
                    if(text.Length > 0)
                    {
                        text = text.Remove(text.Length - 1);
                    }
                } break;
                case Keys.Enter:
                {
                } break;
                case Keys.Escape:
                {
                } break;
                case Keys.Tab:
                {
                } break;
                case Keys.Alt:
                {
                } break;
                case Keys.Control:
                {
                } break;
                case Keys.Shift:
                {
                } break;
            }
        }

        public void Render()
        {
            Screen.graphics.Graphics.FillRectangle(rect_brush, rect);
            Screen.graphics.Graphics.DrawString(text, font, text_brush, text_draw_point);
        }
    }
}
