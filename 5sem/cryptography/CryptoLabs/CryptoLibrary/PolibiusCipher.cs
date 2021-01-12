using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLibrary
{
    public class PolibiusCipher : Cipher
    {
        List<char> square = new List<char>()
        { 
            'a', 'b', 'c', 'd', 'e',
            'f', 'g', 'h', 'i', 'k',
            'l', 'm', 'n', 'o', 'p',
            'q', 'r', 's', 't', 'u',
            'v', 'w', 'x', 'y', 'z'
        };

        public PolibiusCipher(string key)
            : base(key)
        {
            if (key.ToList().Distinct().Count() == key.ToList().Count && key.Length == 5)
            {
                this.key = key;
                InitSquare();
            }
            else
            {
                throw new ArgumentException("Incorrect key");
            }
        }

        public void InitSquare()
        {
            foreach(char c in key)
            {
                square.Remove(c);
            }

            for(int i = key.Length - 1; i >= 0; i--)
            {
                square.Insert(0, key[i]);
            }
        }

        public override string Decrypt(string text)
        {
            string result = default, encCoord = default;

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    char c = text[i];
                    if(c == 'j')
                    {
                        c = 'i';
                    }
                    encCoord += (square.IndexOf(c) / 5).ToString();
                    encCoord += (square.IndexOf(c) % 5).ToString();
                }
            }

            int iCoord = 0;
            int letterNum = 0;

            while (iCoord < encCoord.Length / 2)
            {
                if (char.IsLetter(text[letterNum]))
                {
                    int n = Convert.ToInt32(encCoord[iCoord].ToString()) * 5 + Convert.ToInt32(encCoord[encCoord.Length / 2 + iCoord].ToString());
                    result += square[n];
                    iCoord++;
                }
                else
                {
                    result += text[letterNum];
                }
                letterNum++;
            }
            return result;
        }

        public override string Encrypt(string text)
        {
            string result = default, upperCoord = default, lowerCoord = default, lowerText = text.ToLower();

            for (int i = 0; i < lowerText.Length; i++)
            {
                if (char.IsLetter(lowerText[i]))
                {
                    upperCoord += (square.IndexOf(lowerText[i]) / 5).ToString();
                    lowerCoord += (square.IndexOf(lowerText[i]) % 5).ToString();
                }
            }

            int iCoord = 0;
            string encCoord = upperCoord + lowerCoord;
            int letterNum = 0;

            while(letterNum < text.Length)
            {
                if(char.IsLetter(lowerText[letterNum]))
                {
                    int n = Convert.ToInt32(encCoord[iCoord].ToString()) * 5 + Convert.ToInt32(encCoord[iCoord + 1].ToString());
                    result += square[n];
                    iCoord = iCoord + 2;
                }
                else
                {
                    result += lowerText[letterNum];
                }
                letterNum++;
            }
            return result;
        }
    }
}
