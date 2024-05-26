using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECC
{
    public class EncryptedVersion
    {
        private Point C1;
        private Point C2;
        public EncryptedVersion(Point C1, Point C2)
        {
            this.C1 = C1;
            this.C2 = C2;
        }
        public Point pC1 { get { return this.C1; } }
        public Point pC2 { get { return this.C2; } }
        public override string ToString()
        {
            return "{" + this.C1.ToString() + ", " + this.C2.ToString() + "}";
        }
    }
}
