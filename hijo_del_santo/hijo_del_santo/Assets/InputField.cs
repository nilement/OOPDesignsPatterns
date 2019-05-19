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
    class InputField
    {
        public Point center;
        public int offset;

        public int font_size;
        public Font font;

        public bool is_password;

        public string text;
        public string masked_text;
        public Point text_draw_point;

        public SolidBrush text_brush;
        public Pen rect_pen;
        public Pen rect_focus_pen;

        public Size rect_size;
        public Point rect_draw_point;
        public Rectangle rect;

        public InputField() : this("Default", false, new Point(Screen.width / 2, Screen.height / 2), new Size(400, 400), 5, Color.Black, Color.Black, Color.Red)
        {
        }

        public InputField(string _text, bool _is_password, Point _center, Size _rect_size, int _offset, Color _text_color, Color _rect_color, Color _rect_focus_color)
        {
            text = _text;

            masked_text = "";
            for(int i = 0; i < text.Length; ++i)
            {
                masked_text += "*";
            }

            center = _center;
            rect_size = _rect_size;
            offset = _offset;

            is_password = _is_password;

            UpdateFont();

            text_brush = new SolidBrush(_text_color);
            rect_pen = new Pen(_rect_color);
            rect_focus_pen = new Pen(_rect_focus_color);

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
                                masked_text += "*";
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
                        masked_text = masked_text.Remove(masked_text.Length - 1);
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

        public void Render(bool is_focused = false)
        {
            if(is_focused)
            {
                Screen.graphics.Graphics.DrawRectangle(rect_focus_pen, rect);
            }
            else
            {
                Screen.graphics.Graphics.DrawRectangle(rect_pen, rect);
            }

            if(is_password)
            {
                Screen.graphics.Graphics.DrawString(masked_text, font, text_brush, text_draw_point);
            }
            else
            {
                Screen.graphics.Graphics.DrawString(text, font, text_brush, text_draw_point);
            }
        }
    }
}
