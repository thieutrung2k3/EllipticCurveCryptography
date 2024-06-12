using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECC
{
    class TonelliShanks
    {
        public static int modExp(int bas, int exp, int mod)
        {
            int result = 1;
            bas = bas % mod;
            while (exp > 0)
            {
                if ((exp & 1) == 1)
                {
                    result = (result * bas) % mod;
                }
                exp >>= 1;
                bas = (bas * bas) % mod;
            }
            return result;
        }
        public static int Handle(int n, int p)
        {
            if(modExp(n, (p - 1)/2, p) != 1){
                return -1;
            }
            if (p % 4 == 3)
            {
                return modExp(n, (p + 1) / 4, p);
            }

            int q = p - 1;
            int s = 0;

            while (q % 2 == 0)
            {
                q /= 2;
                s++;
            }

            if (s == 1)
            {
                return modExp(n, (p + 1) / 4, p);
            }

            int z = 2;
            while (modExp(z, (p - 1) / 2, p) == 1)
            {
                z++;
            }

            int m = s;
            int c = modExp(z, q, p);
            int t = modExp(n, q, p);
            int r = modExp(n, (q + 1) / 2, p);

            while (t != 1)
            {
                int temp = t;
                int i;
                for (i = 0; i < m; i++)
                {
                    if (temp == 1)
                    {
                        break;
                    }
                    temp = (temp * temp) % p;
                }

                int b = modExp(c, 1 << (m - i - 1), p);
                m = i;
                c = (b * b) % p;
                t = (t * c) % p;
                r = (r * b) % p;
            }

            return r;
        }
    }
}
