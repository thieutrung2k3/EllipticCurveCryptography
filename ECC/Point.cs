using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECC
{
    public class Point
    {
        private int x;
        private int y;
        public Point()
        {
            this.x = 0;
            this.y = 0;
        }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public override string ToString() { return "[" + this.x + ", " + this.y + "]"; }
    }
}
