using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace hijo_del_santo.Assets
{
    class ItemImage
    {
        public Image image;
        public Point point;
        private Point center;
        private Size size;

        public ItemImage()
        {
            size = new Size(0, 0);
            point = new Point(0, 0);
            center = new Point(0, 0);
        }

        public ItemImage(Point pointC)
        {
            center = pointC;
        }

        public ItemImage(string path, Point pointC)
        {
            image = Image.FromFile(path);
            size = image.Size;
            center = pointC;
            RecalculatePoint();
        }

        public void RecalculatePoint()
        {
            point = new Point(center.X - (size.Width / 2), center.Y - (size.Height / 2));
        }

        public void UpdateImage(string path)
        {
            image = Image.FromFile(path);
            size = image.Size;
            RecalculatePoint();
        }
    }
}
