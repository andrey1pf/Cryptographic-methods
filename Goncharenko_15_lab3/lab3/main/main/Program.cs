using static System.Math;

namespace ConsoleApp1
{
    class Program
    {
        public static StreamWriter sw = new StreamWriter("output.txt");
        public static StreamWriter sw2 = new StreamWriter("output2.txt");
        public static StreamWriter sw3 = new StreamWriter("result.txt");
        public static StreamWriter sw4 = new StreamWriter("resultOneZero.txt");
        public static StreamWriter sw5 = new StreamWriter("resultPart3.txt");
        public static StreamWriter sw6 = new StreamWriter("resultBerlekampaAndMessi.txt");
        public static BinaryWriter bw = new BinaryWriter(File.Open("result.bin", FileMode.Create));
        private static List<string> LFSRMethod(LFSR lfsr)
        {
            List<string> list = new List<string>(); 
            int i = 0;
            do
            {
                list.Add(lfsr.Registry);
                lfsr.Shift();
                list.Add(lfsr.Registry);
                lfsr.Shift();
                ++i;
            } while (list[i] != list[0]);

            for (int j = 0; j < list.Count / 2; ++j)
            {
                sw.Write("\t{0}\t{1}", list[j], "|");
                if(j % 7 == 0) sw.WriteLine();
            }
            sw.WriteLine();
            
            return list;
        }

        private static List<string> sequencePeriod(List<string> list, int n)
        {
            List<string> result = new List<string>();
            int size = list.Count;
            for (int i = 0; i < size; ++i)
            {
                string s = list[i];
                result.Add(s[n-1].ToString());
            }

            for (int i = 0; i < size; ++i)
            {
                if(i % 13 == 0) sw2.WriteLine();
                sw2.Write("\t{0}\t{1}", result[i], "|");
            }
            sw2.WriteLine();
            return result;
        }

        private static List<string> Geffe(List<string> list1, List<string> list2, List<string> list3, int n)
        {
            List<string> result = new List<string>();
            int n1 = list1.Count;
            int n2 = list2.Count;
            int n3 = list3.Count;
        
            for (int i = 0; i < n; ++i)
            {
                if(list1[i % n1] == "1") result.Add(list2[i % n2]);
                else result.Add(list3[i % n3]);
            }
        
            return result;
        }

        private static void PrintResult(List<string> result, int n)
        {
            for (int i = 0; i < n; ++i)
            {
                if(i % 13 == 0) sw3.WriteLine();
                sw3.Write("\t{0}\t{1}", result[i], "|");
            }
        }
        
        private static void PrintBinaryResult(List<string> result, int n)
        {
            for (int i = 0; i < n; ++i)
            {
                if(i % 13 == 0) sw3.WriteLine();
                bw.Write(result[i]);
            }
        }

        private static void CountZeroAndOne(List<string> result)
        {
            int size = result.Count;
            int zero = 0, one = 0;
            
            for(int i = 0; i < size; ++i)
            {
                if(result[i] == "0") ++zero;
                else ++one;
            }
            
            sw4.WriteLine("Количество нулей: {0}", zero);
            sw4.WriteLine("Количество единиц: {0}", one);
        }

        private static void Part3(List<string> result)
        {
            for (int i = 1; i <= 5; ++i)
            {
                int sum = 0;
                for (int j = 1; j <= 10000 - i; ++j)
                {
                    int k = (Convert.ToInt32(result[j - 1]) + Convert.ToInt32(result[j + i - 1])) % 2;
                    if (k == 0) ++sum;
                    else --sum;
                }
                
                sw5.WriteLine("При i = {0} сумма = : {1}", i, sum);
            }
        }

        static void Main(string[] args)
        {
            List<string> listFirst = new List<string>();
            List<string> secondFirst = new List<string>();
            List<string> therdFirst = new List<string>();
            List<string> sequencePeriodFirst = new List<string>();
            List<string> sequencePeriodSecond = new List<string>();
            List<string> sequencePeriodThird = new List<string>();

            LFSR lfsrFirst = new LFSR(5, "01010");
            LFSR lfsrSecond = new LFSR(7, "1100101");
            LFSR lfsrTherd = new LFSR(8, "01000001");

            sw.WriteLine("Первый LFSR: ");
            listFirst = LFSRMethod(lfsrFirst);
            
            sw.WriteLine("Второй LFSR: ");
            secondFirst = LFSRMethod(lfsrSecond);
            
            sw.WriteLine("Третий LFSR: ");
            therdFirst = LFSRMethod(lfsrTherd);

            sw2.WriteLine("Первый период последовательности: ");
            sequencePeriodFirst = sequencePeriod(listFirst, 5);
            sw2.WriteLine("Второй период последовательности: ");
            sequencePeriodSecond = sequencePeriod(secondFirst, 7);
            sw2.WriteLine("Третий период последовательности: ");
            sequencePeriodThird = sequencePeriod(therdFirst, 8);
            
            sw3.WriteLine("Результат Геффе для 10000: ");
            List<string> result = Geffe(sequencePeriodFirst, sequencePeriodSecond, 
                                        sequencePeriodThird, 10000);
            
            PrintResult(result, 10000);
            CountZeroAndOne(result);
            Part3(result);
            
            List<string> resultBin = Geffe(sequencePeriodFirst, sequencePeriodSecond, 
                sequencePeriodThird, 10000000);
            
            PrintBinaryResult(resultBin, 10000000);

            sw.Close();
            sw2.Close();
            sw3.Close();
            sw4.Close();
            sw5.Close();
            sw6.Close();
            bw.Close();
        }

        public static StreamWriter Sw
        {
            get => sw;
            set => sw = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}