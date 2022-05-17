/*using System;
using System.Numerics;
using System.Xml;

namespace ConsoleApp1
{
    class Program
    {
        public static BigInteger GetMin(int bitCount)
        {
            BigInteger start = 1;

            for (int i = 1; i < bitCount; ++i)
            {
                start *= 2;
            }

            return start;
        }

        public static BigInteger GetMax(int bitCount)
        {
            BigInteger start = 1;

            for (int i = 1; i < bitCount; ++i)
            {
                start *= 2;
                start++;
            }

            return start;
        }
        public static BigInteger nod(BigInteger m, BigInteger n)
        {
            while (m != 0 && n != 0)
            {
                if (m >= n)
                    m %= n;
                else
                    n %= m;
            }

            return m + n;
        }

        public static bool MillerRabinTest(BigInteger n, int k)
        {
            if (n % 2 == 0)
            {
                return false;
            }

            BigInteger t = n - 1;
            int s = 0;

            while (t % 2 == 0)
            {
                t /= 2;
                s += 1;
            }

            for (int i = 0; i < k; i++)
            {
                // выберем случайное целое число a в отрезке [2, n − 2]

                BigInteger hight = n - 2;

                BigInteger a = getRandom(1, new BigInteger(2), hight);

                BigInteger temp = new BigInteger(1);
                if (nod(a, n) != temp)
                {
                    return false;
                }

                // x ← a^t mod n, вычислим с помощью возведения в степень по модулю
                BigInteger x = BigInteger.ModPow(a, t, n);

                // если x == 1 или x == n − 1, то перейти на следующую итерацию цикла
                if (x == 1 || x == n - 1)
                    continue;

                // повторить s − 1 раз
                for (int r = 1; r < s; r++)
                {
                    // x ← x^2 mod n
                    x = BigInteger.ModPow(x, 2, n);

                    // если x == 1, то вернуть "составное"
                    if (x == 1)
                    {
                        return false;
                    }

                    // если x == n − 1, то перейти на следующую итерацию внешнего цикла
                    if (x == n - 1)
                        break;
                }

                if (x != n - 1)
                {
                    return false;
                }

            }


            return true;
        }
        
        public static BigInteger getRandom(int length, BigInteger bottom, BigInteger upper)
        {
            Random random = new Random();
            byte[] data = new byte[length];
            random.NextBytes(data);
            BigInteger bi = new BigInteger(data);
            if (bi < 0)
            {
                bi *= -1;
            }

            BigInteger minus = upper - bottom + 1;
            bi = bi % minus;
            bi += bottom;
            return bi;
        }

        static void Main()
        {
            int bitCount = 0;
            bitCount = Convert.ToInt32(Console.ReadLine());
            BigInteger Min = GetMin(bitCount);
            BigInteger Max = GetMax(bitCount);

            BigInteger bi = getRandom(bitCount, Min, Max);
            int y = 0;
            while (MillerRabinTest(bi, (int) (Math.Log(0.0000001) / Math.Log(0.25)) + 1) == false)
            {
                bi = getRandom(bitCount, Min, Max);
                ++y;
            }

            Console.WriteLine(bi);

            Console.WriteLine(y);
        }
    }
}*/

//Solovei-Shtrassen

/*using System;
using System.Numerics;
using System.Security.Cryptography;

namespace Colovei_Shtrassen
{
    class Program
    {
       public static BigInteger nod(BigInteger m, BigInteger n)
        {
            while (m != 0 && n != 0)
            {
                if (m >= n)
                    m %= n;
                else
                    n %= m;
            }
            return m + n;
        }

        public static BigInteger Pows(BigInteger a, BigInteger b)
        {
            BigInteger temp = a;
            for(BigInteger i = 0; i < b - 1; ++i)
            {
                a *= temp;
            }
            return a;
        }

        public static BigInteger Jakobi(BigInteger a, BigInteger n)
        {
            
            if (a == 1)
            {
                return 1;
            }
            if (a < 0)
            {
                //std::cout << pow((-1), ((n - 1) / 2)) << '\n';
                return Pows((-1), ((n - 1) / 2)) * Jakobi(-a, n);

            }
            if (a % 2 == 0)
            {
                //std::cout << pow((-1), ((n * n - 1) / 8)) << '\n';
                return Pows((-1), ((n * n - 1) / 8)) * Jakobi(a / 2, n);

            }
            if (a < n)
            {
                //std::cout << pow((-1), ((a - 1) * (n - 1) / 4)) << '\n';
                return Pows((-1), ((a - 1) * (n - 1) / 4)) * Jakobi(n, a);
            }
            return Jakobi(a % n, n);

        }
        public static bool Solovei_Shtrassen(BigInteger n, int k)
        {
            if (n % 2 == 0)
            {
                return false;
            }


            for (int i = 0; i < k; ++i)
            {
                BigInteger hight = n - 2;

                BigInteger a = getRandom(1, new BigInteger(2), hight);

                BigInteger temp = new BigInteger(1);

                if (nod(a, n) != temp)
                {
                    return false;
                }

                BigInteger r = (-1)*Jakobi(a , n);
                BigInteger s = BigInteger.ModPow(a, ((n-1)/2), n); ;
                if (r == s)
                {
                    return false;
                }
            }

            return true;
        }


        public static BigInteger getRandom(int length, BigInteger bottom, BigInteger upper)
        {
            Random random = new Random();
            byte[] data = new byte[length];
            random.NextBytes(data);
            BigInteger bi = new BigInteger(data);
            if (bi < 0)
            {
                bi *= -1;
            }
            BigInteger minus = upper - bottom + 1;
            bi = bi % minus;
            bi += bottom;
            return bi;
        }
        public static BigInteger GetMin(int numu)
        {
            BigInteger start = 1;

            for (int i = 1; i < numu; ++i)
            {
                start *= 2;
            }
            return start;
        }

        

        public static BigInteger GetMax(int numu)
        {
            BigInteger start = 1;

            for (int i = 1; i < numu; ++i)
            {
                start *= 2;
                start++;
            }
            return start;
        }

        static void Main(string[] args)
        {
            int bit_num;
            int y = 0;
            bit_num = Convert.ToInt32(Console.ReadLine());
            BigInteger MinValue = GetMin(bit_num);
            BigInteger MaxValue = GetMax(bit_num);

            BigInteger bi = getRandom(bit_num, MinValue, MaxValue);

            while (!Solovei_Shtrassen(bi, (int)(Math.Log(0.0000001) / Math.Log(0.5)) + 1) )
            {
                bi = getRandom(bit_num, MinValue, MaxValue);
                ++y;
            }
            //Console.WriteLine(Jakobi(996, 1001));
            Console.WriteLine(bi);
            Console.WriteLine(y);
            // bool v = MillerRabinTest(bi, (int)(Math.Log(0.0000001) / Math.Log(0.25)) + 1);

        }
    }
}*/

//Luc
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Threading.Tasks;

namespace Mersen_Luk
{
    class Program
    {
        public static BigInteger getRandom(int length, BigInteger bottom, BigInteger upper)
        {
            Random random = new Random();
            byte[] data = new byte[length];
            random.NextBytes(data);
            BigInteger bi = new BigInteger(data);
            if (bi < 0)
            {
                bi *= -1;
            }
            
            BigInteger minus = upper - bottom + 1;
            if(minus == 0)
            {
                return bi;
            }
            bi = bi % minus;
            bi += bottom;
            return bi;
        }

        public static BigInteger Pows(BigInteger a, BigInteger b)
        {
            BigInteger temp = a;
            for (BigInteger i = 0; i < b - 1; ++i)
            {
                a *= temp;
            }
            return a;
        }

        public static BigInteger getRandom(int length)
        {
            Random random = new Random();
            byte[] data = new byte[length];
            random.NextBytes(data);
            BigInteger bi = new BigInteger(data);
            return bi;
        }

        public static BigInteger nod(BigInteger m, BigInteger n)
        {
            while (m != 0 && n != 0)
            {
                if (m >= n)
                    m %= n;
                else
                    n %= m;
            }
            return m + n;
        }
        public static bool MillerRabinTest(BigInteger n, int k)
        {
            if (n % 2 == 0)
            {
                return false;
            }
            BigInteger t = n - 1;
            int s = 0;

            while (t % 2 == 0)
            {
                t /= 2;
                s += 1;
            }

            for (int i = 0; i < k; i++)
            {
                

                BigInteger hight = n - 2;

                BigInteger a = getRandom(1, new BigInteger(2), hight);

                BigInteger temp = new BigInteger(1);
                if (nod(a, n) != temp)
                {
                    return false;
                }

                BigInteger x = BigInteger.ModPow(a, t, n);

        
                if (x == 1 || x == n - 1)
                    continue;

      
                for (int r = 1; r < s; r++)
                {
             
                    x = BigInteger.ModPow(x, 2, n);

            
                    if (x == 1)
                    {
                        return false;
                    }


                    if (x == n - 1)
                        break;
                }

                if (x != n - 1)
                {
                    return false;
                }
                
            }
            return true;
        }


        public static BigInteger GetMin(int numu)
        {
            BigInteger start = 1;

            for (int i = 1; i < numu; ++i)
            {
                start *= 2;
            }
            return start;
        }

        

        public static BigInteger GetMax(int numu)
        {
            BigInteger start = 1;

            for (int i = 1; i < numu; ++i)
            {
                start *= 2;
                start++;
            }
            return start;
        }

        private static Boolean isMersennePrime(int p)
        {
            if (p % 2 == 0) { 
                return (p == 2); 
            }

            for (int i = 3; i <= (int)Math.Sqrt(p); i += 2)
            {
                if (p % i == 0)
                { 
                    return false; //not prime
                }
            }
            BigInteger m_p = BigInteger.Pow(2, p) - 1;
            BigInteger s = 4;
            BigInteger k = new BigInteger(1);
            while (k != p - 1)
            {
                s = BigInteger.ModPow((s * s - 2), 1, m_p);
                ++k;
            }
            return s == 0;
        }

        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: System.UInt32[]")]
        static void Main(string[] args)
        {
            BigInteger max = new BigInteger(25);
            
            
            BigInteger num = getRandom(1, 3, max);

            do
             {
                 while (MillerRabinTest(num, (int)(Math.Log(0.0000001) / Math.Log(0.25)) + 1) != true)
                 {
                     num = getRandom(1, 3, max);
                 }
             } while (isMersennePrime((int)num) != true);

           
            Console.WriteLine("Сгенерированная степень: ");
            Console.WriteLine(num);
            BigInteger bi = new BigInteger(2);
            Console.WriteLine("Сгенерированное число мерсена: ");
            BigInteger mersen_num = Pows(bi, num) - 1;
            Console.WriteLine(mersen_num);
        }
    }
}