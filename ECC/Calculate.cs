using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECC
{
    public class Calculate
    {
        #region Find the inverse element
        public static int FindTheInverseElement(int b, int a)
        {
            if (b < 0)
            {
                b = b + a;
            }
            int a_last = a;
            int[] s = new int[100];
            int[] t = new int[100];
            int[] q = new int[100];
            int i = 0;
            while (b != 0)
            {
                q[i + 1] = (int)a / b;
                if (i == 0)
                {
                    s[i] = 1;
                    t[i] = 0;
                }
                else if (i == 1)
                {
                    s[i] = 0;
                    t[i] = 1;
                }
                else
                {
                    s[i] = s[i - 2] - s[i - 1] * q[i - 1];
                    t[i] = t[i - 2] - t[i - 1] * q[i - 1];
                }
                int temp = b;
                b = a % b;
                a = temp;
                i++;
            }
            if (i == 0)
            {
                s[i] = 1;
                t[i] = 0;
            }
            else if (i == 1)
            {
                s[i] = 0;
                t[i] = 1;
            }
            else
            {
                s[i] = s[i - 2] - s[i - 1] * q[i - 1];
                t[i] = t[i - 2] - t[i - 1] * q[i - 1];
            }
            if (t[i] < 0)
            {
                return t[i] + a_last;
            }
            return t[i] % a_last;
        }
        #endregion
        #region Find Infinity Point
        public static Point CalculatePoint(Point g, Point p, int a, int z)
        {
            int s;
            if (g.X == p.X && g.Y == p.Y)
            {
                s = (((3 * g.X * g.X + a) % z) * FindTheInverseElement(2 * g.Y, z)) % z;
            }
            else
            {
                s = ((g.Y - p.Y) * FindTheInverseElement(g.X - p.X, z)) % z;
            }
            int x_new = ((s * s) - g.X - p.X) % z;
            int y_new = (s * (p.X - x_new) - p.Y) % z;
            return new Point((x_new + z) % z, (y_new + z) % z);
        }

        public static int FindInfinityPoint(Point g, int a, int z)
        {
            Point p = CalculatePoint(g, g, a, z);
            int i = 3;
            while (g.X != p.X)
            {
                p = CalculatePoint(g, p, a, z);
                i++;
            }
            return i;
        }
        #endregion
        public static Point MultiplyByNumber(Point p, int k, int a, int z)
        {
            Point p2 = p;
            int count = 1;
            while (count < k)
            {
                p2 = CalculatePoint(p, p2, a, z);
                count++;
            }
            return p2;
        }
        public static Point Negate(Point p, int z)
        {
            return new Point(p.X, -p.Y + z);
        }
    }
}
