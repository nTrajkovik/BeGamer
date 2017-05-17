using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeGamer
{
    public class Platform : Shape
    {
        Rectangle platform;
        public Platform(Point pos, Color color, Size size)
        {
            Position = pos;
            Color = color;
            platform = new Rectangle(pos, size);
        }

        public override void Draw(Graphics g)
        {
            Brush br = new SolidBrush(Color);
            g.FillRectangle(br, platform);
            br.Dispose();
        }
    }
}
