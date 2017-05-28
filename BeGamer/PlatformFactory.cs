using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public Platform Next(int WindowWidth, int WindowHeight)
        {
            platformWidth = random.Next(50, 200);
            platformHeight = random.Next(30, 60);

            Xcoor = WindowWidth + (platformWidth / 2);
            Ycoor = random.Next(WindowHeight - 200, WindowHeight - 50);
            Point pos = new Point(Xcoor, Ycoor);
            Platform nextPlatform = new Platform(pos, Color.Yellow, new Size(platformWidth, platformHeight));
            return nextPlatform;
        }
    }
}
