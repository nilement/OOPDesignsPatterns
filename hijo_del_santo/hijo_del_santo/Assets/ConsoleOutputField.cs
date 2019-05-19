using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Text;

namespace hijo_del_santo.Assets
{
    class ConsoleOutputField
    {
        public Point center;
        public int offset;

        public int font_size;
        public Font font;

        public string text;
        public SizeF text_size;
        public string visible_text;
        public Point text_draw_point;

        public SolidBrush text_brush;
        public SolidBrush rect_brush;

        public Size rect_size;
        public Point rect_draw_point;
        public Rectangle rect;

        public ConsoleOutputField() : this("test\n", new Point(Screen.width / 2, Screen.height / 8), new Size(Screen.width, Screen.height / 4), 5, 50, Color.Black, Color.Gray)
        {
        }

        public ConsoleOutputField(string _text, Point _center, Size _rect_size, int _offset, int _font_size, Color _text_color, Color _rect_color)
        {
            text = _text;
            center = _center;
            rect_size = _rect_size;
            offset = _offset;
            font_size = _font_size;

            font = new Font(new FontFamily(GenericFontFamilies.Monospace), font_size, GraphicsUnit.Pixel);

            text_size = Screen.graphics.Graphics.MeasureString(text, font);

            text_brush = new SolidBrush(_text_color);
            rect_brush = new SolidBrush(_rect_color);

            rect_draw_point = new Point(0, 0);
            text_draw_point = new Point(0, 0);
            UpdateDrawPoints();
            rect = new Rectangle(rect_draw_point, rect_size);
        }

        public void UpdateDrawPoints()
        {
            rect_draw_point.X = center.X - rect_size.Width / 2;
            rect_draw_point.Y = center.Y - rect_size.Height / 2;

            text_draw_point.X = rect_draw_point.X + offset;
            text_draw_point.Y = rect_draw_point.Y + rect_size.Height - ((int)text_size.Height + offset);
        }

        public bool Contains(Point point)
        {
            return rect.Contains(point);
        }

        public void UpdateText(string _text)
        {
            text = _text;
            text_size = Screen.graphics.Graphics.MeasureString(text, font);

            text_draw_point.X = rect_draw_point.X + offset;
            text_draw_point.Y = rect_draw_point.Y + rect_size.Height - ((int)text_size.Height + offset);
        }

        public void AddText(string _text)
        {
            UpdateText(text + _text);
        }

        public void Render()
        {
            Screen.graphics.Graphics.FillRectangle(rect_brush, rect);
            Screen.graphics.Graphics.DrawString(text, font, text_brush, text_draw_point);
        }
    }
}
