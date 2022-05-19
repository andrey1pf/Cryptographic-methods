using System.Numerics;

namespace main;

public class DixonFactorizationMethod
{
    private static double GetRandomNumber(double minimum, double maximum)
    {
        Random random = new Random();
        double result = random.NextDouble() * (maximum - minimum) + minimum;

        while (Math.Abs(result - maximum) == 0)
        {
            result = random.NextDouble() * (maximum - minimum) + minimum;
        }
        return result;
    }
    private static List<double> GetPrimesInRange(double num)
    {
        List<double> primes = new List<double>();
        primes.Add(2);
        for (int i = 1; i <= num; i = i + 2)
        {
            if (DetermineIsPrime(i) == true && i > 1)
            {
                primes.Add(i);
            }
        }
        return primes;
    }
    
    private static bool DetermineIsPrime(double num)
    {
        int y;
        List<int> divisors = new List<int>();
        double x = Math.Sqrt((int)num);
        y = (int)Math.Ceiling(x);
        if (num == 3 || num == 2)
        {
            return true;
        }
        for (int counter = 1; counter <= y + 1; counter++)
        {
            if (num % counter == 0)
            {
                divisors.Add(counter);
                if (divisors.Count > 1)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static List<double> pairs = new();
    public static List<double> a = new();

    private static void func(int n, int start, List<double> list)
    {
        double lhs = 0, rhs = 0;
        for (int i = start; i < n; ++i)
        {
            for (int j = 0; j < list.Count; ++j)
            {
                lhs = Math.Pow(i, 2) % n;
                rhs = Math.Pow(list[j], 2) % n;
                if (lhs == rhs)
                {
                    a.Add(i);
                    pairs.Add(list[j]);
                }
            }
        }

        List<double> newvec = new List<double>();
        int len = pairs.Count;

        for (int i = 0; i < len; ++i)
        {
            int factor = (int) Program.gcd((BigInteger) (a[i] - pairs[i]), n);
            if (factor != 1)
            {
                newvec.Add(factor);
            }
        }

        newvec = newvec.Distinct().ToList();

        Console.WriteLine(n + " = " + newvec[0] + " * " + newvec[1]);
    }

    public static void Start(int n)
    {
        double m = Math.Sqrt(Math.Exp(Math.Sqrt(Math.Log(n) * Math.Log(Math.Log(n)))));
        double b = GetRandomNumber(Math.Sqrt(n), n);
        double a = Math.Pow(b, 2) % n;
        List<double> list = new List<double>();
        list = GetPrimesInRange(m);
        int start = (int)Math.Sqrt(n);
        func(n,start,list);
    }
}