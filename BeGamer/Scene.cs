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
        private List<Shape> shapes;
        private List<Entity> entities;
        public Scene()
        {
            shapes = new List<Shape>();
            entities = new List<Entity>();
        }
        public void Draw(Graphics g)
        {
            foreach (Shape s in shapes)
            {
                s.Draw(g);
            }
            foreach (Entity e in entities)
            {
                e.ApplyGravity(gravity);
                e.Draw(g);
            }
        }
        public void CheckCollision()
        {
            foreach(Entity e in entities)
            {
                foreach(Shape s in shapes)
                {
                    //if(e.bounds)
                }
            }
        }
        public void AddToScene(Shape x)
        {
            if(x is Entity)
            {
                Entity tmp = x as Entity;
                if(tmp != null) {
                    entities.Add(tmp);
                }
            }
            else { 
                shapes.Add(x);
            }
        }
    }
}
