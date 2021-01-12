using CryptoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherLibrary
{
    public class VegenereCipher : Cipher
    {
        const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string secretKey;

        public VegenereCipher(string key)
           : base(key)
        {
            secretKey = key;
            if (!key.Any(x => char.IsDigit(x)))
            {
                this.key = key;
            }
            else
            {
                throw new ArgumentException("Incorrect key");
            }
        }

        public override string Decrypt(string text)
        {
            InitSecretKey(text);
            int n = 0;
            string result = default;

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    n = (alphabet.Length + alphabet.IndexOf(text.ToUpper()[i]) + alphabet.IndexOf(secretKey.ToUpper()[i])) % alphabet.Length;
                    result += alphabet[n];
                }
                else
                {
                    result += text[i];
                }
            }

            return result.ToLower();
        }

        public override string Encrypt(string text)
        {
            InitSecretKey(text);
            int n = 0;
            string result = default;

            for(int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    n = (alphabet.Length + alphabet.IndexOf(text.ToUpper()[i]) - alphabet.IndexOf(secretKey.ToUpper()[i])) % alphabet.Length;
                    result += alphabet[n];
                }
                else
                {
                    result += text[i];
                }
            }

            return result;
        }

        public void InitSecretKey(string text)
        {
            while (secretKey.Length <= text.Length)
            {
                secretKey += key;
            }
            secretKey = secretKey.Substring(0, text.Length);
        }
    }
}
