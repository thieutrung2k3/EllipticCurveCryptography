using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECC
{
    public class AutoGenerate
    {
        #region Generate Random Prime
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            int boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        public static int GenerateRandomPrime(int min, int max)
        {
            Random random = new Random();
            int number;

            do
            {
                number = random.Next(min, max + 1);
            } while (!IsPrime(number));

            return number;
        }
        #endregion
        public static void AutoGenerateConst(ref int a, ref int b)
        {
            Random random = new Random();
            a = random.Next(1, 10);
            b = random.Next(1, 10);
        }
        public static Point AutoGenerateG(int a, int b, int z)
        {
            Random random = new Random();
            while (true)
            {
                int x;
                if(z < 300)
                {
                    x = random.Next(1, z);
                }
                else
                {
                    x = random.Next(1, 300);
                }
                int e = (x * x * x + a * x + b) % z;
                for (int i = 0; i < z; i++)
                {
                    if ((i * i) % z == e)
                    {
                        return new Point(x, i);
                    }
                }
            }
            /*Random random = new Random();
            int x = random.Next(1, z);
            int e = (x * x * x + a * x + b) % z;
            int y = TonelliShanks.Handle(e, z);
            return new Point(x, y);*/
        }
        public static void AutoGeneratePoint(List<Point> pointsList, int x, int a, int b, int z)
        {
            int e = (x * x * x + a * x + b) % z;
            for (int i = 0; i < z; i++)
            {
                if ((i * i) % z == e)
                {
                    pointsList.Add(new Point(x, i));
                    break;
                }
            }
            /*int y = TonelliShanks.Handle(e, z);
            if (y != -1)
            {
                pointsList.Add(new Point(x, y));
            }*/
        }
    }
}
