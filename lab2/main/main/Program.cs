using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        //шифр простой замены
        public static void encryption(int key, List<char> alphabet)
        {
            StreamWriter sw = new StreamWriter("messageS.txt");
            StreamReader sr = new StreamReader("message.txt");

            string message = sr.ReadLine();
            var arrayList = new List<char>();

            for (int i = 0; i < message.Length; ++i)
            {
                if (message[i] != ' ')
                {
                    int index = 0;
                    for (int j = 0; j < alphabet.Count; ++j)
                    {
                        if (message[i] == alphabet[j]) arrayList.Add(alphabet[(j+key)%26]);
                    }
                }
            }

            for (int i = 0; i < arrayList.Count; ++i)
            {
                sw.Write(arrayList[i]);
            }
            
            sw.Close();
            sr.Close();
        }
        
        public static StreamWriter swdh = new StreamWriter("decryptionHack.txt");
        public static StreamWriter swd = new StreamWriter("message.txt");
        public static void decryption(int key, List<char> alphabet, int file)
        {
            StreamReader srd = new StreamReader("messageS.txt");
            StreamReader srdh = new StreamReader("encryptionHack.txt");
            string message;
            if (file == 0) 
            {
                message = srd.ReadLine();
            }
            else
            {
                message = srdh.ReadLine();
            }
            

            var arrayList = new List<char>();

            for (int i = 0; i < message.Length; ++i)
            {
                if (message[i] != ' ')
                {
                    int index = 0;
                    for (int j = 0; j < alphabet.Count; ++j)
                    {
                        if (message[i] == alphabet[j]) arrayList.Add(alphabet[((j-key)+26)%26]);
                    }
                }
            }

            if (file == 0)
            {
                for (int i = 0; i < arrayList.Count; ++i)
                {
                    swd.Write(arrayList[i]);
                }
            }
            
            else
            {
                for (int i = 0; i < arrayList.Count; ++i)
                {
                    swdh.Write(arrayList[i]);
                }
                swdh.WriteLine("");
                swdh.WriteLine("-----------------");
            }
            swd.Close();
            srd.Close();
            srdh.Close();
        }

        // Шифр Виженера
        
        /*
         * Если n  — количество букв в алфавите, m_j — номер буквы открытого текста,
         * k_j — номер буквы ключа в алфавите, то шифрование Виженера можно записать следующим образом:
         *
         * c_j=(m_j+k_j) mod n
         */

        public static void encryptionVigner(string key, List<char> alphabet)
        {
            StreamReader srv = new StreamReader("messageVigner.txt");
            StreamWriter swv = new StreamWriter("messageSVigner.txt");

            var list = new List<char>();
            string line = srv.ReadLine();

            for (int i = 0; i < line.Length; ++i)
            {
                int m = 0, k = 0;
                
                string a = Convert.ToString(line[i]);
                string b = Convert.ToString(key[i]);

                for (int j = 0; j < 26; ++j)
                {
                    if (a == Convert.ToString(alphabet[j])) m = j;
                    if (b == Convert.ToString(alphabet[j])) k = j;
                }
                
                list.Add(alphabet[(m+k)%26]);
            }

            for (int i = 0; i < list.Count; ++i)
            {
                swv.Write(list[i]);
            }
            
            srv.Close();
            swv.Close();
        }
        
        public static void decryptionVigner(string key, List<char> alphabet)
        {
            StreamReader desrv = new StreamReader("messageSVigner.txt");
            StreamWriter deswv = new StreamWriter("messageVigner.txt");

            var list = new List<char>();
            string line = desrv.ReadLine();

            for (int i = 0; i < line.Length; ++i)
            {
                int c = 0, k = 0;
                
                string a = Convert.ToString(line[i]);
                string b = Convert.ToString(key[i]);

                for (int j = 0; j < 26; ++j)
                {
                    if (a == Convert.ToString(alphabet[j])) c = j;
                    if (b == Convert.ToString(alphabet[j])) k = j;
                }

                int ind = (c - k) % 26;
                if (c - k < 0) ind = 26 + (c - k);
                list.Add(alphabet[ind]);
            }

            for (int i = 0; i < list.Count; ++i) {
                deswv.Write(list[i]);
            }
            desrv.Close();
            deswv.Close();
        }
        
        //hack key

        
        public static void hack(List<char> alp)
        {
            for (int j = 1; j < 25; ++j)
            {
                decryption(j, alp, 1);
            }
            swdh.Close();
        }

        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("key.txt");
            StreamReader srv = new StreamReader("keyVigner.txt");
            int key = Convert.ToInt32(streamReader.ReadLine());
            var alphabet = new List<char>();
            string alp = "abcdefghijklmnopqrstuvwxyz";

            for (int i = 0; i < 26; ++i)
            {
                alphabet.Add(alp[i]);
            }
            
            Console.WriteLine("encryption or decryption? [e/d]");
            string answer = Console.ReadLine();
            if (answer == "e")
            {
                encryption(key, alphabet);
            }

            if (answer == "d")
            {
                decryption(key, alphabet, 0);
            }
            streamReader.Close();
            
            //-----------------------------

            
            string keyV = srv.ReadLine();
            
            Console.WriteLine("encryption or decryption? [e/d]");
            string answerV = Console.ReadLine();
            if (answerV == "e")
            {
                encryptionVigner(keyV, alphabet);
            }

            if (answerV == "d")
            {
                decryptionVigner(keyV, alphabet);
            }
            srv.Close();
            
            //-----------------------------
            
            hack(alphabet);
        }
    }
}