using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeGamer
{
    public abstract class Entity : Shape
    {
        public int dX { get; set; }
        public int dY { get; set; }
        public abstract void Move();
        public void ApplyGravity(int g)
        {
            dY += g;
        }
    }
}
