using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp1;

public class LFSR
{
    bool[] bits;
    int[] tapSequence;
    public string seed;

    public LFSR(int bitCount, string seed, int[] tapSequence)
    {
        this.seed = seed;
        bits = new bool[bitCount];

        for (int i = 0; i < bitCount; i++)
        {
            bits[i] = seed[i] == '1' ? true : false;
        }
        this.tapSequence = tapSequence;
    }

    public int n = 0;
    //[SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: System.String")]
    public string Registry()
    {
        n = 0;
        for(int i = 0; i < tapSequence.Length - 1; ++i)
        {
            if (bits[tapSequence[i]] == true)
            {
                n += 1;
            }
        }
        
        n %= 2;
        Shift();
        bits[^1] = n == 1 ? true : false;
        char[] t = new char[bits.Length];
        for (int i = 0; i < bits.Length; i++)
            if(bits[i] == true)
                t[i] = '1';
            else
                t[i] = '0';

        return new string(t);
    }

    public void Shift()
    {
        for (int i = 0; i < bits.Length - 1; ++i)
        {
            bits[i] = bits[i + 1];
        }
    }

    public string returnLine()
    {
        return seed;
    }

    /*0,1,3,4
    * 01010, 00101, 10010,
    */
    
    
    /*public string Registry
    {
        get
        {
            char[] t = new char[bits.Length];
            for (int i = 0; i < bits.Length; i++)
                t[i] = bits[i] ? '1' : '0';

            return new string(t);
        }
    }

    public void Shift()
    {
        bool bnew = !(bits[bits.Length - 1] == bits[bits.Length - 2]);

        for (int i = bits.Length-1; i > 0; i--)
        {
            bits[i] = bits[i-1];
        }
        bits[0] = bnew;
    }*/
}