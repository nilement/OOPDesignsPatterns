using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Text;

namespace hijo_del_santo.Assets
{
    class TextField
    {
        public PointF center;

        public int font_size;
        public Font font;
        public SolidBrush brush;

        public string text;
        public SizeF text_size;
        public PointF draw_point;

        public TextField() : this("Default", 50, new Point(Screen.width / 2, Screen.height / 2), Color.Black)
        {
        }

        public TextField(string _text, int _font_size, Point _center, Color _text_color)
        {
            text = _text;
            font_size = _font_size;
            center = _center;

            font = new Font(new FontFamily(GenericFontFamilies.Monospace), font_size, GraphicsUnit.Pixel);
            text_size = Screen.graphics.Graphics.MeasureString(text, font);

            brush = new SolidBrush(_text_color);

            draw_point = new PointF(0.0f, 0.0f);
            UpdateDrawPoints();
        }

        public void UpdateDrawPoints()
        {
            text_size = Screen.graphics.Graphics.MeasureString(text, font);

            draw_point.X = center.X - text_size.Width / 2.0f;
            draw_point.Y = center.Y - text_size.Height / 2.0f;
        }

        public void UpdateText(string _text)
        {
            text = _text;
            UpdateDrawPoints();
        }

        public void UpdateColor(Color _color)
        {
            brush.Color = _color;
        }

        public void Render()
        {
            Screen.graphics.Graphics.DrawString(text, font, brush, draw_point);
        }
    }
}
