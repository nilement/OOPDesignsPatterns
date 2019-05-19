using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Text;

namespace hijo_del_santo.Assets
{
    class RectButton
    {
        public PointF center;

        public int font_size;
        public Font font;

        public string text;
        public SizeF text_size;
        public PointF text_draw_point;

        public SolidBrush text_brush;
        public SolidBrush rect_brush;
        public SolidBrush rect_toggle_brush;

        public SizeF rect_size;
        public PointF rect_draw_point;
        public RectangleF rect;

        public RectButton()
        {
            text = "Default";
            font_size = 50;
            font = new Font(new FontFamily(GenericFontFamilies.Monospace), font_size, GraphicsUnit.Pixel);
            text_size = Screen.graphics.Graphics.MeasureString(text, font);
            text_draw_point = new PointF(0.0f, 0.0f);

            text_brush = new SolidBrush(Color.White);
            rect_brush = new SolidBrush(Color.Black);
            rect_toggle_brush = new SolidBrush(Color.Black);

            center = new PointF(Screen.width / 2.0f, Screen.height / 2.0f);
            rect_size = new SizeF(400, 400);
            rect_draw_point = new PointF(0.0f, 0.0f);
            UpdateDrawPoints();
            rect = new RectangleF(rect_draw_point, rect_size);
        }

        public RectButton(Color _text_color, Color _rect_color, PointF _center, SizeF _rect_size, string _text = "Default", int _font_size = 50)
        {
            text = _text;
            font_size = _font_size;
            font = new Font(new FontFamily(GenericFontFamilies.Monospace), font_size, GraphicsUnit.Pixel);
            text_size = Screen.graphics.Graphics.MeasureString(text, font);
            text_draw_point = new PointF(0.0f, 0.0f);

            text_brush = new SolidBrush(_text_color);
            rect_brush = new SolidBrush(_rect_color);
            rect_toggle_brush = new SolidBrush(_rect_color);

            center = _center;
            rect_size = _rect_size;
            rect_draw_point = new PointF(0.0f, 0.0f);
            UpdateDrawPoints();
            rect = new RectangleF(rect_draw_point, rect_size);
        }

        public RectButton(Color _text_color, Color _rect_color, Color _rect_toggle_color, PointF _center, SizeF _rect_size, string _text = "Default", int _font_size = 50)
        {
            text = _text;
            font_size = _font_size;
            font = new Font(new FontFamily(GenericFontFamilies.Monospace), font_size, GraphicsUnit.Pixel);
            text_size = Screen.graphics.Graphics.MeasureString(text, font);
            text_draw_point = new PointF(0.0f, 0.0f);

            text_brush = new SolidBrush(_text_color);
            rect_brush = new SolidBrush(_rect_color);
            rect_toggle_brush = new SolidBrush(_rect_toggle_color);

            center = _center;
            rect_size = _rect_size;
            rect_draw_point = new PointF(0.0f, 0.0f);
            ResizeText();
            rect = new RectangleF(rect_draw_point, rect_size);
        }

        public void UpdateDrawPoints()
        {
            text_draw_point.X = center.X - text_size.Width / 2.0f;
            text_draw_point.Y = center.Y - text_size.Height / 2.0f;

            rect_draw_point.X = center.X - rect_size.Width / 2.0f;
            rect_draw_point.Y = center.Y - rect_size.Height / 2.0f;
        }

        public void ResizeText()
        {
            while((text_size.Width > rect_size.Width ||
                  text_size.Height > rect_size.Height) && (font_size > 11))
            {
                --font_size;
                font = new Font(new FontFamily(GenericFontFamilies.Monospace), font_size, GraphicsUnit.Pixel);
                text_size = Screen.graphics.Graphics.MeasureString(text, font);
            }
            UpdateDrawPoints();
        }

        public void UpdateText(string _text)
        {
            text = _text;
            text_size = Screen.graphics.Graphics.MeasureString(text, font);
            ResizeText();
        }

        public bool Contains(PointF point)
        {
            return rect.Contains(point);
        }

        public void Render(bool is_toggled = false)
        {
            if(is_toggled)
            {
                Screen.graphics.Graphics.FillRectangle(rect_toggle_brush, rect);
            }
            else
            {
                Screen.graphics.Graphics.FillRectangle(rect_brush, rect);
            }
            Screen.graphics.Graphics.DrawString(text, font, text_brush, text_draw_point);
        }
    }
}
