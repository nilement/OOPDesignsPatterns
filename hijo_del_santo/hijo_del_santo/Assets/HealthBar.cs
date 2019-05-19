using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Text;

namespace hijo_del_santo.Assets
{
    class HealthBar
    {
        public PointF center;
        public int offset;

        public string text;
        public int hit_points;
        public int max_hit_points;

        public SizeF text_size;
        public float font_size;
        public Font font;
        public PointF text_draw_point;

        public SolidBrush text_brush;
        public SolidBrush outer_rect_brush;
        public SolidBrush inner_rect_brush;

        public SizeF outer_rect_size;
        public RectangleF outer_rect;
        public RectangleF inner_rect;

        public HealthBar() : this(
            new PointF(0, 0),
            5, 100, 100,
            Color.Black, Color.FromArgb(255, 200, 0, 0), Color.FromArgb(255, 100, 0, 0),
            new SizeF(300, 100))
        {
        }

        public HealthBar(PointF _center, int _hit_points, int _max_hit_points, SizeF _outer_rect_size) : this(
            _center, 5, _hit_points, _max_hit_points,
            Color.Black, Color.FromArgb(255, 200, 0, 0), Color.FromArgb(255, 100, 0, 0),
            _outer_rect_size)
        {
        }

        public HealthBar(PointF _center, int _offset, int _hit_points, int _max_hit_points, SizeF _outer_rect_size) : this(
            _center, _offset, _hit_points, _max_hit_points,
            Color.Black, Color.FromArgb(255, 200, 0, 0), Color.FromArgb(255, 100, 0, 0),
            _outer_rect_size)
        {
        }

        public HealthBar(PointF _center, int _offset, int _hit_points, int _max_hit_points, Color _text_color, Color _outer_rect_color, Color _inner_rect_color, SizeF _outer_rect_size)
        {
            center = _center;
            offset = _offset;
            hit_points = _hit_points;
            max_hit_points = _max_hit_points;
            outer_rect_size = _outer_rect_size;

            UpdateFont();
            UpdateText();

            text_brush = new SolidBrush(_text_color);
            outer_rect_brush = new SolidBrush(_outer_rect_color);
            inner_rect_brush = new SolidBrush(_inner_rect_color);

            outer_rect = new Rectangle(0, 0, 0, 0);
            inner_rect = new Rectangle(0, 0, 0, 0);
            outer_rect.Size = outer_rect_size;
            UpdateDrawPoints();
        }

        public void UpdateText()
        {
            text = hit_points.ToString() + "/" + max_hit_points.ToString();
            text_size = Screen.graphics.Graphics.MeasureString(text, font);
        }

        public void UpdateFont()
        {
            font_size = outer_rect_size.Height - 2 * offset;
            font = new Font(new FontFamily(GenericFontFamilies.Monospace), font_size, GraphicsUnit.Pixel);
        }

        public void UpdateDrawPoints()
        {
            outer_rect.X = center.X - outer_rect.Width / 2;
            outer_rect.Y = center.Y - outer_rect.Height / 2;

            inner_rect.Width = (outer_rect.Width - 2 * offset) * (float)hit_points / (float)max_hit_points;
            inner_rect.Height = outer_rect.Height - 2 * offset;

            inner_rect.X = outer_rect.X + offset;
            inner_rect.Y = outer_rect.Y + offset;

            text_draw_point.X = center.X - text_size.Width / 2;
            text_draw_point.Y = center.Y - text_size.Height / 2 + offset;
        }

        public void UpdateMaxHitPoints(int _max_hit_points)
        {
            if(_max_hit_points < 0)
            {
                max_hit_points = 0;
            }
            else
            {
                max_hit_points = _max_hit_points;
            }

            UpdateText();
            UpdateDrawPoints();
        }

        public void UpdateHitPoints(int _hit_points)
        {
            if(_hit_points < 0)
            {
                hit_points = 0;
            }
            else
            {
                hit_points = _hit_points;
            }

            UpdateText();
            UpdateDrawPoints();
        }

        public void Render()
        {
            Screen.graphics.Graphics.FillRectangle(outer_rect_brush, outer_rect);
            Screen.graphics.Graphics.FillRectangle(inner_rect_brush, inner_rect);
            Screen.graphics.Graphics.DrawString(text, font, text_brush, text_draw_point);
        }
    }
}
