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
        public int MaxSpeed { get; set; }
        public bool Collided { get; set; }
        public Color Color { get; set; }
        public int dX { get; set; }
        public int dY { get; set; }

        public Player(Point startPos, Color color, int dmg, int hp)
        {
            //Position = startPos;
            player = new Rectangle(startPos, new Size(25, 50));
            Color = color;
            Damage = dmg;
            Health = hp;
            MaxSpeed = 21;
            dX = 0;
            dY = 0;
        }
        
        public void Draw(Graphics g)
        {
            using (Brush br = new SolidBrush(Color))
            {
                player.Location = new Point(player.Location.X + dX, player.Location.Y + dY);
                g.FillRectangle(br, player);
            }
        }
        public void ApplyGravity(int g)
        {
            dY += g;
        }
        
        public void StopX()
        {
            dX = 0;
        }
        public void StopY()
        {
            dY = 0;
        }

        public void CollisionFix(Rectangle difference)
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
                    player.Location = new Point(player.Location.X - difference.Width, player.Location.Y);
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

        }
    


        //internal bool CanMove(Direction dir)
        //{
        //    bool collided = CheckCollision(dir);
        //    bool maxSpeed = true;
        //    switch (dir)
        //    {
        //        case Entity.Direction.UP:
        //        case Entity.Direction.DOWN:
        //            if (Math.Abs(dY) > MaxSpeed)
        //                maxSpeed = false;
        //            break;
        //        case Entity.Direction.LEFT:
        //        case Entity.Direction.RIGHT:
        //            if (Math.Abs(dX) > MaxSpeed)
        //                maxSpeed = false;
        //            break;
        //        default:
        //            Console.WriteLine("Something is wrong (Entity.Direction)");
        //            break;
        //    }
        //    return maxSpeed && !collided;
        //}

        //private bool CheckCollision(Direction dir)
        //{
        //    //switch (dir)
        //    //{
        //    //    case Entity.Direction.UP:
        //    //        return CollidedYneg;
        //    //    case Entity.Direction.DOWN:
        //    //        return CollidedYpos;
        //    //    case Entity.Direction.LEFT:
        //    //        return CollidedXneg;
        //    //    case Entity.Direction.RIGHT:
        //    //        return CollidedXpos;
        //    //    default:
        //    //        Console.WriteLine("Something is wrong with collision");
        //    //        break;
        //    //}
        //    return false;
        //}
    }
}
