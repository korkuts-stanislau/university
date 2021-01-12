using CryptoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherLibrary
{
    public class PermutationCipher : Cipher
    {
        new int[] key;
        public PermutationCipher(string key)
            : base(key)
        {
            this.key = ToIntArray(key);
        }

        public override string Decrypt(string text)
        {
            string result = default;
            string[] table = new string[(int)Math.Ceiling((double)text.Length / (double)key.Length)];
            int textIndex = 0;
            for (int i = 0; i < table.Length; i++)
            {
                if (textIndex + key.Length <= text.Length)
                {
                    table[i] = text.Substring(textIndex, key.Length);
                }
                else
                {
                    table[i] = text.Substring(textIndex, text.Length - textIndex);
                }
                textIndex += key.Length;
            }
            ReformTable(table, text);
            string[] resultTable = new string[table.Length];
            Array.Copy(table, resultTable, table.Length);

            for (int i = 0; i < key.Length; i++)
            {
                ReplaceColumns(table, resultTable, i, key[i] - 1);
            }

            for (int i = 0; i < resultTable.Length; i++)
            {
                for (int j = 0; j < resultTable[i].Length; j++)
                {
                    result += resultTable[i][j];
                }
            }

            result = result.Trim();
            return result;
        }

        public override string Encrypt(string text)
        {
            string result = default;
            string[] table = new string[(int)Math.Ceiling((double)text.Length / (double)key.Length)];
            int textIndex = 0;
            for(int i = 0; i < table.Length; i++)
            {
                if (textIndex + key.Length <= text.Length)
                {
                    table[i] = text.Substring(textIndex, key.Length);
                }
                else
                {
                    table[i] = text.Substring(textIndex, text.Length - textIndex);
                    if (table[i].Length < key.Length)
                    {
                        while(key.Length - table[i].Length != 0)
                        {
                            table[i] += " ";
                        }
                    }
                }
                textIndex += key.Length;
            }

            int keyValue = 1;
            for(int i = 0; i < key.Length; i++)
            {
                result += ToStringFromColumn(table, Array.FindIndex(key, x => x == keyValue));
                keyValue++;
            }

             return result;
        }

        public void ReformTable(string[] table, string text)
        {
            int columnNum = 0, textNum = 0;
            while(columnNum < table[0].Length)
            {
                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i].Length > columnNum)
                    {
                        table[i] = ReplaceAtIndex(columnNum, text[textNum], table[i]);
                        if(textNum < text.Length - 1) textNum++;
                    }
                }
                columnNum++;
            }
        }

        public void ReplaceColumns(string[] table, string[] resultTable, int prevColumn, int nextColumn)
        {
            for (int i = 0; i < table.Length; i++)
            {
                resultTable[i] = ReplaceAtIndex(prevColumn, table[i][nextColumn], resultTable[i]);
            }
        }

        public string ToStringFromColumn(string[] table, int columnNum)
        {
            string res = default;

            for(int i = 0; i < table.Length; i++)
            {
                if(table[i].Length > columnNum)
                {
                    res += table[i][columnNum];
                }
            }

            return res;
        }

        public int[] ToIntArray(string text)
        {
            string[] numbers = text.Split(' ');
            int[] res = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                res[i] = Convert.ToInt32(numbers[i]);
            }
            return res;
        }

        public string ReplaceAtIndex(int i, char value, string word)
        {
            char[] letters = word.ToCharArray();
            letters[i] = value;
            return string.Join("", letters);
        }
    }
}
