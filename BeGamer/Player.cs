using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeGamer
{
    public class Player : Entity
    {
        public Rectangle player;
        public int Health { get; set; }
        public int Damage { get; set; }
        public Player(Point startPos, Color color, int dmg, int hp)
        {
            Position = startPos;
            player = new Rectangle(startPos, new Size(25, 50));
            Color = color;
            Damage = dmg;
            Health = hp;
            dX = 1;
            dY = 0;
        }
        
        public override void Draw(Graphics g)
        {
            Position = new Point(Position.X + dX, Position.Y + dY);
            Brush br = new SolidBrush(Color);
            g.FillRectangle(br, player);
            br.Dispose();
        }

        public override void Move()
        {

        }
        public void Shoot()
        {

        }
    }
}
