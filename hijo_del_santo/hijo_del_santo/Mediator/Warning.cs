using System;
using System.Drawing;
using hijo_del_santo.Assets;

namespace hijo_del_santo.Mediator
{
    class Warning :  RectButton, IColleague
    {
        private SolidBrush enabledColor;
        private SolidBrush enabledTextColor;
        private SolidBrush disabledColor = new SolidBrush(Color.FromArgb(0, 255, 255, 255));
        public bool IsEnabled;

        public Warning(Color _text_color, Color _rect_color, PointF _center, SizeF _rect_size, string _text = "Default", int _font_size = 50) : base(_text_color, _rect_color, _center, _rect_size, _text, _font_size)
        {
            enabledColor = new SolidBrush(_rect_color);
            enabledTextColor = new SolidBrush(_text_color);
            IsEnabled = false;
            text_brush = disabledColor;
            rect_brush = disabledColor;
        }

        public void Enable()
        {
            IsEnabled = true;
            text_brush = enabledTextColor;
            rect_brush = enabledColor;
        }

        public void Disable()
        {
            IsEnabled = false;
            text_brush = disabledColor;
            rect_brush = disabledColor;
        }
    }
}
