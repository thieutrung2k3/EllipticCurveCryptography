using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECC
{
    public class Values
    {
        public List<EncryptedVersion> encryptedVersions;
        public List<Point> listConvert;
        public Point G;
        public int a, b, z, n, d;
        public Values(List<EncryptedVersion> encryptedVersions,List<Point> listConvert, int a, int b, int z, int n, int d, Point g)
        {
            this.encryptedVersions = encryptedVersions;
            this.listConvert = listConvert;
            this.a = a;
            this.b = b;
            this.z = z;
            this.n = n;
            this.d = d;
            G = g;
        }
        public int getZ()
        {
            return z;
        }
        public int getA()
        {
            return a;
        }
        public int getB()
        {
            return b;
        }
        public List<Point> getListConvert()
        {
            return listConvert;
        }
        public Point getG()
        {
            return G;
        }
    }
}
