using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using hijo_del_santo.Assets;

namespace hijo_del_santo.Assets
{
    class ItemList
    {
        public int item_count;

        public PointF center;
        public SizeF size;
        public int offset;
        public SolidBrush rect_brush;
        public PointF rect_draw_point;
        public RectangleF rect;

        public RectButton[] buttons;
        public Color text_color;
        public Color button_color1;
        public Color button_color2;
        public Color toggle_color1;
        public Color toggle_color2;

        public bool toggleable;
        public int toggled_index;

        public ItemList() : this(new string[]{ "Test", "Test", "Test", "Test", "Test" }, new PointF(Screen.width / 2.0f, Screen.height / 2.0f), new SizeF(Screen.width / 6.0f, Screen.height / 4.0f), 5, Color.Gray, Color.White, Color.DarkBlue, Color.DarkRed)
        {
        }

        public ItemList(string[] _items, PointF _center, SizeF _size, int _offset, Color _background, Color _text, Color _button1, Color _button2) : this(_items, _center, _size, _offset, _background, _text, _button1, _button1, _button2, _button2)
        {
        }

        public ItemList(string[] _items, PointF _center, SizeF _size, int _offset, Color _background, Color _text, Color _button1, Color _toggle1, Color _button2, Color _toggle2, bool _toggleable = false)
        {
            item_count = _items.Length;
            buttons = new RectButton[item_count];
            center = _center;
            size = _size;
            offset = _offset;
            text_color = _text;
            button_color1 = _button1;
            button_color2 = _button2;
            toggle_color1 = _toggle1;
            toggle_color2 = _toggle2;
            toggleable = _toggleable;
            toggled_index = -1;

            rect_brush = new SolidBrush(_background);
            UpdateDrawPoints();
            rect = new RectangleF(rect_draw_point, size);

            float button_height = (size.Height - 2.0f * offset) / item_count;
            float button_width = size.Width - 2.0f * offset;

            for(int i = 0; i < item_count; ++i)
            {
                PointF button_center = new PointF(center.X, rect_draw_point.Y + offset + i * button_height + button_height / 2.0f);
                SizeF button_size = new SizeF(button_width, button_height);
                Color button_color = i % 2 == 0 ? button_color1 : button_color2;
                Color toggle_color = i % 2 == 0 ? toggle_color1 : toggle_color2;
                int font_size = (int)(0.6f * button_height);

                buttons[i] = new RectButton(text_color, button_color, toggle_color, button_center, button_size, _items[i], font_size);
            }
        }

        public void UpdateDrawPoints()
        {
            rect_draw_point.X = center.X - size.Width / 2.0f;
            rect_draw_point.Y = center.Y - size.Height / 2.0f;
        }

        public void UpdateItemList(string[] _items)
        {
            item_count = _items.Length;
            buttons = new RectButton[item_count];

            float button_height = (size.Height - 2.0f * offset) / item_count;
            float button_width = size.Width - 2.0f * offset;

            for(int i = 0; i < item_count; ++i)
            {
                PointF button_center = new PointF(center.X, rect_draw_point.Y + offset + i * button_height + button_height / 2.0f);
                SizeF button_size = new SizeF(button_width, button_height);
                Color button_color = i % 2 == 0 ? button_color1 : button_color2;
                Color toggle_color = i % 2 == 0 ? toggle_color1 : toggle_color2;
                int font_size = (int)(0.6f * button_height);

                buttons[i] = new RectButton(text_color, button_color, toggle_color, button_center, button_size, _items[i], font_size);
            }
        }

        public int GetClickedIndex(PointF _point)
        {
            for(int i = 0; i < item_count; ++i)
            {
                if(buttons[i].Contains(_point))
                {
                    if(toggleable)
                    {
                        if(toggled_index == i)
                        {
                            toggled_index = -1;
                        }
                        else
                        {
                            toggled_index = i;
                        }
                        return toggled_index;
                    }
                    return i;
                }
            }
            toggled_index = -1;
            return toggled_index;
        }

        public void Render()
        {
            Screen.graphics.Graphics.FillRectangle(rect_brush, rect);
            for(int i = 0; i < item_count; ++i)
            {
                if(i != toggled_index)
                {
                    buttons[i].Render();
                }
                else
                {
                    buttons[i].Render(true);
                }
            }
        }
    }
}
