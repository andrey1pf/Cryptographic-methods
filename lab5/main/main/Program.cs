using System;
using System.Numerics;
using System.Xml;
using main;
using Microsoft.VisualBasic;

class Program
{
    public static BigInteger gcd(BigInteger x, BigInteger y)
    {
        while (x != y)
        {
            if (x > y)
                x = x - y;
            else
                y = y - x;
        }
        return x;
    }
    
    private static List<BigInteger> Gcd(BigInteger a, BigInteger b)
    {
        var arr = new List<BigInteger>();
        var list = new List<BigInteger>();
        var res = new List<BigInteger>();
        BigInteger x1, y1, r;
        if (b == 0)
        {
            x1 = 1;
            y1 = 0;
            arr.Add(a);
            arr.Add(x1);
            arr.Add(y1);
            return arr;
        }
        list = Gcd(b, a % b);
        r = list[0];
        x1 = list[1];
        y1 = list[2];
        res.Add(r);
        res.Add(y1);
        res.Add(x1 - a / b * y1);
        return res;
    }
    
    private static BigInteger ModPow(BigInteger baseNum, BigInteger exponent, BigInteger modulus)
    {
        BigInteger pow = 1;
        if (modulus == 1)
            return 0;
        BigInteger curPow = baseNum % modulus;
        BigInteger res = 1;
        while(exponent > 0){
            if (exponent % 2 == 1)
                res = (res * curPow) % modulus;
            exponent /= 2;
            curPow = (curPow * curPow) % modulus;
        }
        return res;
    }
    
    private static BigInteger FindingThePrivateKey(BigInteger p, BigInteger q, BigInteger e, BigInteger n)
    {
        BigInteger phi = (p - 1) * (q - 1);
        Console.WriteLine("[+] Phi = " + phi);
        if (gcd(e, phi) != 1)
        {
            Console.WriteLine("[-] Incorrect value 'e': " + e);
            return 1;
        }

        var res = new List<BigInteger>();
        res = Gcd(e, phi);
        return res[1];
    }

    private static BigInteger RSAEncription(BigInteger x1, BigInteger e, BigInteger n)
    {
        BigInteger y1 = ModPow(x1, e, n);
        return y1;
    }

    private static BigInteger RSADecription(BigInteger y1, BigInteger d, BigInteger n)
    {
        BigInteger res = ModPow(y1, d, n);
        return res;
    }

    private static bool Comparison(BigInteger x, BigInteger y)
    {
        if (x == y) return true;
        return false;
    }

    private static void ReturnAllResalt(BigInteger p, BigInteger q, BigInteger e, BigInteger x1, BigInteger y2)
    {
        BigInteger d = 0, x2 = 0, y1 = 0, x1res = 0;
        BigInteger n = p * q;
        Console.WriteLine("[+] n = " + n);
        d = FindingThePrivateKey(p, q, e, n);
        Console.WriteLine("[+] Private key: " + d);
        y1 = RSAEncription(x1, e, n);
        x1res = RSADecription(y1, d, n);
        x2 = RSADecription(y2, d, n);
        Console.WriteLine("[+] Y1: " + y1);
        Console.WriteLine("[+] X2: " + x2);
        Console.WriteLine("[+] Decoded X1: " + x1);
        Console.WriteLine("[+] Decoded Y1: " + x1res);
        if (Comparison(x1, x1res))
            Console.WriteLine("[+] The original value X1 and the value after decryption matched");
        else Console.WriteLine("[-] The original value X1 and the value after decryption did not match");
    }

    public static void Main()
    {
        BigInteger p = 801410357975153, q = 950867021741191, e = 0, x1 = 0, y2 = 0;
        string eLine = "110066171603901969362593059313";
        string x1Line = "651256495894733822754552878879";
        string y2Line = "253970845268857814403399216528";
        e = BigInteger.Parse(eLine);
        x1 = BigInteger.Parse(x1Line);
        y2 = BigInteger.Parse(y2Line);
        ReturnAllResalt(p, q, e, x1, y2);
        DixonFactorizationMethod.Start(23449);
    }
}
