using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLibrary
{
    public class CeasarCipher : Cipher
    {
        int keyInt;
        public CeasarCipher(string key)
            : base(key)
        {
            if (!int.TryParse(key, out int a))
            {
                throw new InvalidCastException("The key must be an integer!");
            }
            else
            {
                keyInt = int.Parse(key);
            }
        }

        public override string Decrypt(string text)
        {
            char[] charText = text.ToUpper().ToCharArray();

            for (int i = 0; i < charText.Length; i++)
            {
                if (char.IsLetter(charText[i]))
                {
                    int n = ((int)charText[i]) - keyInt;
                    if (n < 65)
                    {
                        n = n + 26;
                    }
                    charText[i] = (char)n;
                }
            }

            return new string(charText).ToLower();
        }

        public override string Encrypt(string text)
        {
            char[] charText = text.ToUpper().ToCharArray();

            for(int i = 0; i < charText.Length; i++)
            {
                if (char.IsLetter(charText[i]))
                {
                    int n = ((int)charText[i]) + keyInt;
                    if (n > 90)
                    {
                        n = n - 26;
                    }
                    charText[i] = (char)n;
                }
            }

            return new string(charText);
        }
    }
}
