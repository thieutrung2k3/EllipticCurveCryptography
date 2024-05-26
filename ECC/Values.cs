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
        public int a, b, z, n, d;
        public Values(List<EncryptedVersion> encryptedVersions, int a, int b, int z, int n, int d)
        {
            this.encryptedVersions = encryptedVersions;
            this.a = a;
            this.b = b;
            this.z = z;
            this.n = n;
            this.d = d;
        }
    }
}
