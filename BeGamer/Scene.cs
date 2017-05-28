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
        private const int gravity = 1;
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
            players.ForEach(a => { a.ApplyGravity(gravity); a.Draw(g); });
            enemies.ForEach(a => { a.ApplyGravity(gravity); a.Draw(g); });
            platforms.ForEach(a => { a.Draw(g); });
        }
        public void Destroy()
        {
            List<Platform> removePlatform = new List<Platform>();
            List<Enemy> removeEnemy = new List<Enemy>();
            
            platforms.ForEach(a => {
                if (a.ShouldDie())
                    removePlatform.Add(a);
                    });
            enemies.ForEach(a => {
                if (a.ShouldDie())
                    removeEnemy.Add(a);
            });
            
            removePlatform.ForEach(a => platforms.Remove(a));
            removeEnemy.ForEach(a => enemies.Remove(a));

        }
        /// <summary>
        /// Detects collision and calls CollisionFix on the entities to adjust them to touch
        /// the platform with which they collide
        /// </summary>
        public void CheckCollision()
        {
            foreach (Player player in players)
            {
                foreach (Platform platform in platforms)
                {
                    foreach (Enemy enemy in enemies)
                    {
                        //Player collision with platform
                        if (player.NextPosition().IntersectsWith(platform.platform))
                        {
                            player.CollisionFix(platform.platform);
                        }
                        else
                        {
                            player.Color = Color.Purple;
                        }
                        //Enemy collision with platform
                        if (enemy.NextPosition().IntersectsWith(platform.platform))
                        {
                            enemy.CollisionFix(platform.platform);
                        }
                        //Player and Enemy collision
                        if (player.player.IntersectsWith(enemy.enemy))
                        {
                            player.TakeDamage();
                        }
                    }
                }
            }
        }
        public void AddToScene(Platform platform)
        {
            platforms.Add(platform);
        }

        public void AddToScene(Enemy enemy)
        {
            enemies.Add(enemy);
        }
        public int EntitiesCount()
        {
            return platforms.Count + enemies.Count;
        }

        public void AddToScene(Player player)
        {
            players.Add(player);
        }
    }
}
