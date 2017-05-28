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
        public bool CanJump { get; set; }

        public Enemy(Point startPos, Color color, int dmg, int hp)
        {
            enemy = new Rectangle(startPos, new Size(25, 50));
            Color = color;
            Damage = dmg;
            Health = hp;
            dX = -5;
            dY = 0;
            CanJump = true;
        }

        public void Draw(Graphics g)
        {
            using (Brush br = new SolidBrush(Color))
            {
                enemy.Location = new Point(enemy.Location.X + dX, enemy.Location.Y + dY);
                g.FillRectangle(br, enemy);
            }
        }
        public void ApplyGravity(int g)
        {
            if (Math.Abs(dY) <= 15)
            {
                dY += g;
            }
        }
        public bool ShouldDie()
        {
            return enemy.Location.X < -enemy.Width;
        }

        public void Jump()
        {
            dY += 6;
        }
        public void StopX()
        {
            dX = 0;
        }
        public void StopY()
        {
            dY = 0;
        }
        public Rectangle NextPosition()
        {
            return new Rectangle(new Point(enemy.Location.X + dX, enemy.Location.Y + dY), enemy.Size);
        }
        public void CollisionFix(Rectangle platform)
        {
            enemy = NextPosition();
            if (enemy.IntersectsWith(platform))
            {
                Rectangle difference = Rectangle.Intersect(platform, enemy);
                if (!difference.IsEmpty)
                {

                    if (difference.Width < difference.Height)
                    {
                        if (enemy.Location.X > difference.Location.X)
                        {
                            //move player to the right
                            enemy.Location = new Point(enemy.Location.X + difference.Width, enemy.Location.Y);
                        }
                        else if (enemy.Location.X < difference.Location.X)
                        {
                            //move player to the left
                            enemy.Location = new Point(enemy.Location.X - difference.Width - 5, enemy.Location.Y);
                        }
                        StopX();
                    }
                    else
                    {
                        if (enemy.Location.Y > difference.Location.Y)
                        {
                            //move player down
                            enemy.Location = new Point(enemy.Location.X, enemy.Location.Y + difference.Height);
                        }
                        else if (enemy.Location.Y < difference.Location.Y)
                        {
                            //move player up
                            enemy.Location = new Point(enemy.Location.X, enemy.Location.Y - difference.Height);
                        }
                        StopY();
                    }
                    //player.CollisionFix(difference);//Calculate the difference and return player to right position
                    Color = Color.Green;
                    CanJump = true;
                }
            }
        }
    }
}
