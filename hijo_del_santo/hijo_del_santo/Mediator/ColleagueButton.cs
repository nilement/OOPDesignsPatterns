using System;
using System.Drawing;
using hijo_del_santo.Assets;

namespace hijo_del_santo.Mediator
{
    class ColleagueButton : RectButton, IColleague
    {
        private SolidBrush enabledColor;
        private SolidBrush disabledColor = new SolidBrush(Color.Gray);

        public ColleagueButton(Color _text_color, Color _rect_color, PointF _center, SizeF _rect_size, string _text = "Default", int _font_size = 50) : base(_text_color, _rect_color, _center, _rect_size, _text, _font_size)
        {
            enabledColor = new SolidBrush(_rect_color);
        }

        public void Enable()
        {
            rect_brush = enabledColor;
        }

        public void Disable()
        {
            rect_brush = disabledColor;
        }
    }
}
