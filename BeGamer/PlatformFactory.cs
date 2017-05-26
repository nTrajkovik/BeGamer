using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeGamer
{
    public class PlatformFactory
    {
        private Random random;
        int platformWidth;
        int platformHeight;
        int Xcoor;
        int Ycoor;
        public PlatformFactory()
        {
            random = new Random();
        }
        public Platform Next()
        {
            platformWidth = random.Next(25, 300);
            platformHeight = random.Next(25, 50);
            Xcoor = Width + (platformWidth / 2);
            Ycoor = random.Next(Height - 200, Height - 50);
            Point pos = new Point(Xcoor, Ycoor);
            Platform nextPlatform = new Platform(pos, Color.Yellow, new Size(platformWidth, platformHeight));
            return 
        }
    }
}
