using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace tasks
{
    public class algoritms2
    {
        public static string[,] ShowVizener()
        {
            string[,] table = new string[33, 33];
            int num = 1072;
            for(int i = 1; i < 33; i++)
            {
                table[0, i] = Convert.ToChar(num).ToString();
                num++;
            }
            num = 1072;
            for(int i = 1; i < 33; i++)
            {
                for(int j = 0; j < 33; j++)
                {
                    if (num == 1104)
                        num = 1072;
                    table[i, j] = Convert.ToChar(num).ToString();
                    num++;
                }
            }
            return table;
        }
        public static string Task1_1(string s, string[,] table)
        {
            s = s.Replace(" ", "");
            List<int> numbers = new List<int>();
            foreach (char c in s)
            {
                int temp = (int)c;
                temp -= 1072;
                numbers.Add(temp);
            }
            string newstr = "";
            for(int i = 0; i < numbers.Count; i += 2)
            {
                newstr += table[numbers[i] + 1, numbers[i + 1] + 1];
            }
            return newstr;
        }
        public static string Task1_2(string s, string[,] table)
        {
            string result = "";
            Random random = new Random();
            foreach (char c in s)
            {
                int rand = random.Next(1, 33);
                for (int i = 0; i < 33; i++)
                {
                    int j = 0;
                    if (table[rand, i] == c.ToString())
                        result += table[rand, 0] + table[0, i] + " ";
                }
            }
            return result;
        }
    }
}
