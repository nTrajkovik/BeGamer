using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeGamer
{
    public class Scene
    {
        private const int gravity = 0;
        private List<Player> players;
        private List<Enemy> enemies;
        private List<Platform> platforms;
        public Scene()
        {
            platforms = new List<Platform>();
            players = new List<Player>();
            enemies = new List<Enemy>();
        }
        public void Draw(Graphics g)
        {
            players.ForEach(a => { /*a.ApplyGravity(gravity);*/ a.Draw(g); });
            enemies.ForEach(a => { a.ApplyGravity(gravity); a.Draw(g); });
            platforms.ForEach(a => { a.Draw(g); });
        }
        public void CheckCollision(Player player)
        {
            //foreach (Player player in players)
            //{
            foreach (Platform platform in platforms)
            {

                if (player.player.IntersectsWith(platform.platform))
                {
                    Rectangle difference = Rectangle.Intersect(platform.platform, player.player);
                    if (!difference.IsEmpty)
                    {
                        //Calculate the difference and return player to right position
                        player.StopX();
                        player.StopY();
                    }
                    player.Color = Color.Green;
                    
                }
                else
                {
                }

            }
            //}
        }
        public void AddToScene(Platform platform)
        {
            platforms.Add(platform);
        }

        public void AddToScene(Enemy enemy)
        {
            enemies.Add(enemy);
        }

        public void AddToScene(Player player)
        {
            players.Add(player);
        }
    }
}
