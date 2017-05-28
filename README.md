# BeGamer
Endless pixel platformer - BeGamer

Windows Forms Project by: 
Nenad Trajkovikj
---
**Македонски** 
##1. Опис на апликацијата
Оваа апликација е игра која процедурално се генерира нивото, т.е. секој пат ќе биде различно. Целта на играта е да се освојат што е можно повеќе бодови преку преживување.
Играта завршува кога играчот ќе испадне од платформите или пак кога ќе нема повеќе HP(животни поени). Се губат животни поени (HP) кога непријател ќе ве допре.

##2. Контроли
Играта се игра со копчињатa:
W - скок
A - лево
D - десно

##3. Претставување на проблемот
Потребата од исцртување на повеќе објекти доведе до потреба да се направи wrapper класа за сите нив. Scene објектот представува таква класа која се грижи за исцртување на сите објекти 
како и детекција на колизија помеѓу различните типиви на објекти.

###3.1 Податочни структури

Дел од функциите содржат **xml _summary_**.

```c#
public class Scene
    {
        private const int gravity = 1;
        private List<Player> players;
        private List<Enemy> enemies;
        private List<Platform> platforms;
        /// <summary>
        /// Constructor for a Scene object
        /// </summary>
        public Scene()
        {
            platforms = new List<Platform>();
            players = new List<Player>();
            enemies = new List<Enemy>();
        }
        /// <summary>
        /// Function used for drawing all three entitiy types and applying gravity to Players and Enemies
        /// </summary>
        /// <param name="g">The graphics context</param>
        public void Draw(Graphics g)
        {
            players.ForEach(a => { a.ApplyGravity(gravity); a.Draw(g); });
            enemies.ForEach(a => { a.ApplyGravity(gravity); a.Draw(g); });
            platforms.ForEach(a => { a.Draw(g); });
        }
        /// <summary>
        /// Removing the elements which are out of the screen (ShouldDie())
        /// </summary>
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
        /// the platform with which they will collide
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
        public void AddToScene(Player player)
        {
            players.Add(player);
        }
    }
```

**English**
##1. Description
This application is a game which is procedurally generated, i.e. the level will be different each time the game is played. The goal of the game is to survive as long as possible, thereby accumulating more and more points. The game ends when the player falls off of the platforms or when the HP pool is depleted. You loose HP when an enemy touches you.

##2. How to play
The controlls are simple:
W - Jump
A - Move Left
D - Move Right