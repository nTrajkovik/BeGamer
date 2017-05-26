using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeGamer
{
    public class Enemy
    {
        public Rectangle enemy;
        public int Health { get; set; }
        public int Damage { get; set; }
        public int MaxSpeed { get; set; }
        public bool Collided { get; set; }
        public Color Color { get; set; }
        public int dX { get; set; }
        public int dY { get; set; }
        public Enemy(Point startPos, Color color, int dmg, int hp)
        {
            enemy = new Rectangle(startPos, new Size(25, 50));
            Color = color;
            Damage = dmg;
            Health = hp;
            dX = -5;
            dY = 0;
        }

        public void Draw(Graphics g)
        {
            using (Brush br = new SolidBrush(Color))
            {
                enemy.Location = new Point(enemy.Location.X + dX, enemy.Location.Y + dY);
                g.FillRectangle(br, enemy);
            }
        }
        
        public void Jump()
        {

        }
    }
}
