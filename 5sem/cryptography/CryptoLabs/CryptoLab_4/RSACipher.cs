using CryptoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLabs
{
    public class RSACipher
    {
        const int e = 5;
        const int n = 323;
        const int d = 173;
        // p = 17, q = 19, n = p * q, phi = (p-1) * (q-1), e = 5, 7, 11..., (d*e)%phi = 1

        public string Decrypt(string text)
        {
            List<string> values = text.Split(' ').ToList();
            values.RemoveAll(x => x.Length == 0);
            byte[] bytes = new byte[values.Count];

            for(int i = 0; i < values.Count; i++)
            {
                bytes[i] = (byte)GetRest(d, Convert.ToInt32(values[i]));
            }

            return Encoding.ASCII.GetString(bytes);
        }

        public string Encrypt(string text)
        {
            string result = "";
            var bytes = Encoding.ASCII.GetBytes(text);

            foreach(byte b in bytes)
            {
                result += GetRest(e, b) + " ";
            }

            return result;
        }

        public int GetRest(int exp, int num)
        {
            int res = 1;
            for(int i = 0; i < exp; i++)
            {
                res = (res * num) % n;
            }
            return res;
        }
    }
}
