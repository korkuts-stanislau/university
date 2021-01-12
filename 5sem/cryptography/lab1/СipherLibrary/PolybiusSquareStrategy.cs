using System;
using System.Collections.Generic;
using System.Text;

namespace СipherLibrary
{
    public class PolybiusSquareStrategy : CipherStrategy
    {
        char[,] charMatrix;

        public PolybiusSquareStrategy()
        {
            charMatrix = new char[,]
            {
                {'A', 'B', 'C', 'D', 'E' },
                {'F', 'G', 'H', 'I', 'K' },
                {'L', 'M', 'N', 'O', 'P' },
                {'Q', 'R', 'S', 'T', 'U' },
                {'V', 'W', 'X', 'Y', 'Z' }
            };
        }

        public string Decrypt(string textToDecrypt)
        {
            StringBuilder builder = new StringBuilder(textToDecrypt.Length);
            for (int i = 0; i < textToDecrypt.Length; i += 2)
            {
                if (i == textToDecrypt.Length - 1)
                {
                    builder.Append(i.ToString());
                }
                try
                {
                    int row = int.Parse(textToDecrypt.Substring(i, 1));
                    int column = int.Parse(textToDecrypt.Substring(i + 1, 1));
                    builder.Append(charMatrix[row - 1, column - 1]);
                }
                catch
                {
                    builder.Append(textToDecrypt[i]);
                    i -= 1;
                }
            }
            return builder.ToString();
        }

        public string Encrypt(string textToEncrypt)
        {
            textToEncrypt = textToEncrypt.ToUpper();
            StringBuilder builder = new StringBuilder();
            foreach(char c in textToEncrypt)
            {
                if (c == 'J')
                    builder.Append("24");
                string coords = getSymbolCoordsInStringFormat(c);
                if(coords.Equals(""))
                {
                    builder.Append(c);
                }
                else
                {
                    builder.Append(coords);
                }
            }
            return builder.ToString();
        }
        private string getSymbolCoordsInStringFormat(char c)
        {
            for(int i = 0; i < 5; i++)
                for(int j = 0; j < 5; j++)
                {
                    if (c == charMatrix[i, j])
                        return ((i + 1) * 10 + (j + 1)).ToString();
                }
            return "";
        }
    }
}
