using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECC
{
    public class EllipticCurveCryptography
    {

        public static Values ToEncrypt(string s)
        {
            List<Point> pointsList = new List<Point>();
            List<EncryptedVersion> encryptedVersionsList = new List<EncryptedVersion>();
            Random rnd = new Random();
            int a = 0, b = 0, z = 0, n = 0, d = 0;
            Point G = new Point();
            int[] asciiArray = new int[s.Length];
            for (int i = 0; i < asciiArray.Length; i++)
            {
                asciiArray[i] = ExceptionHandleASCII.ConvertToInt(s[i]);
                
            }
            while (pointsList.Count != asciiArray.Length)
            {
                pointsList.Clear();
                encryptedVersionsList.Clear();
                a = rnd.Next(1000, 2000);
                b = rnd.Next(1000, 2000);
                z = AutoGenerate.GenerateRandomPrime(320, 360);
                G = AutoGenerate.AutoGenerateG(a, b, z);
                n = Calculate.FindInfinityPoint(G, a, z);
                for (int i = 0; i < asciiArray.Length; i++)
                {
                    int xPoint = asciiArray[i];
                    AutoGenerate.AutoGeneratePoint(pointsList, xPoint, a, b, z);
                }
            }
            foreach (Point point in pointsList)
            {
                Console.WriteLine(point.ToString());
            }
            d = rnd.Next(1, n - 1);

            Point Q = Calculate.MultiplyByNumber(G, d, a, z);
            int k = rnd.Next(1, n - 1);
            Point C1 = Calculate.MultiplyByNumber(G, k, a, z);
            Point kQ = Calculate.MultiplyByNumber(Q, k, a, z);

            if (pointsList.Count == asciiArray.Length)
            {
                foreach (Point M in pointsList)
                {
                    Point C2 = Calculate.CalculatePoint(M, kQ, a, z);
                    encryptedVersionsList.Add(new EncryptedVersion(C1, C2));
                }
            }
            return new Values(encryptedVersionsList, pointsList, a, b, z, n, d, G);
        }
        public static string ToDecrypt(Values values)
        {
            String plainText = "";
            foreach (EncryptedVersion C in values.encryptedVersions)
            {
                Point dC1 = Calculate.MultiplyByNumber(C.pC1, values.d, values.a, values.z);
                Point M = Calculate.CalculatePoint(C.pC2, Calculate.Negate(dC1, values.z), values.a, values.z);
                plainText += ExceptionHandleASCII.ConverToChar(M.X);
            }
            return plainText;
        }
    }
}

