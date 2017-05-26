using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeGamer
{
    public class Platform
    {
        public Rectangle platform;
        public Color Color { get; set; }

        public Platform(Point pos, Color color, Size size)
        {
            Color = color;
            platform = new Rectangle(pos, size);
        }

        public void Draw(Graphics g)
        {
            using (Brush br = new SolidBrush(Color))
            {
                //platform.Location = new Point(platform.Location.X - 5, platform.Location.Y);
                g.FillRectangle(br, platform);
            }
        }
    }
}
