using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeGamer
{
    public class Player
    {
        public Rectangle player;
        public int Health { get; set; }
        public int Damage { get; set; }
        public bool Collided { get; set; }
        public Color Color { get; set; }
        public int dX { get; set; }
        public int dY { get; set; }
        public bool CanJump { get; set; }
        public int MaxXSpeed { get; set; }
        public int MaxYSpeed { get; set; }
        public bool IsAlive { get; set; }
        public bool IsImmune { get; set; }

        public Player(Point startPos, Color color, int dmg, int hp)
        {
            player = new Rectangle(startPos, new Size(25, 50));
            Color = color;
            Damage = dmg;
            Health = hp;
            IsImmune = false;
            MaxYSpeed = 30;
            MaxXSpeed = 15;
            dX = 5;
            dY = -4;
            IsAlive = true;
            CanJump = false;
        }

        public void Draw(Graphics g)
        {
            using (Brush br = new SolidBrush(Color))
            {
                player = NextPosition();
                g.FillRectangle(br, player);
            }
        }

        public void CheckOutOfScreen(int Height, int Width)
        {
            if (player.Location.X < 0 || player.Location.X > Width)
            {
                IsAlive = false;
            }
            if (player.Location.Y < 0 || player.Location.Y > Height)
            {
                IsAlive = false;
            }
        }

        public void ApplyGravity(int g)
        {
            if (Math.Abs(dY) <= MaxYSpeed)
            {
                dY += g;
            }
        }
        public void MoveLeft()
        {
            if(CanAccelerateXAxis()) { 
                dX -= 6;
            }
        }
        public void MoveRight()
        {
            if (CanAccelerateXAxis())
            {
                dX += 6;
            }
        }
        public bool CanAccelerateXAxis()
        {
            return Math.Abs(dX) <= MaxXSpeed;
        }
        public Rectangle NextPosition()
        {
            return new Rectangle(new Point(player.Location.X + dX, player.Location.Y + dY), player.Size);
        }

        public void StopX()
        {
            dX = 0;
        }
        public void StopY()
        {
            dY = 0;
        }

        public void CollisionFix(Rectangle platform)
        {
            player = NextPosition();
            if (player.IntersectsWith(platform))
            {
                Rectangle difference = Rectangle.Intersect(platform, player);
                if (!difference.IsEmpty)
                {
             
            if (difference.Width < difference.Height)
            {
                if (player.Location.X > difference.Location.X)
                {
                    //move player to the right
                    player.Location = new Point(player.Location.X + difference.Width, player.Location.Y);
                }
                else if (player.Location.X < difference.Location.X)
                {
                    //move player to the left
                    player.Location = new Point(player.Location.X - difference.Width - 5, player.Location.Y);
                }
                StopX();
            }
            else
            {
                if (player.Location.Y > difference.Location.Y)
                {
                    //move player down
                    player.Location = new Point(player.Location.X, player.Location.Y + difference.Height);
                }
                else if (player.Location.Y < difference.Location.Y)
                {
                    //move player up
                    player.Location = new Point(player.Location.X, player.Location.Y - difference.Height);
                }
                StopY();
            }
                    //player.CollisionFix(difference);//Calculate the difference and return player to right position
                    Color = Color.Green;
                    CanJump = true;
                }
            }
        }
        /// <summary>
        /// Function which makes the player take damage, 
        /// turns him red and makes him immune. If player has less health than 1 
        /// he is marked dead;
        /// </summary>
        public void TakeDamage()
        {
            if (!IsImmune) { 
                Health -= 1;
                Color = Color.Red;
                if(Health < 1)
                {
                    IsAlive = false;
                }
            }
        }
    }
}
