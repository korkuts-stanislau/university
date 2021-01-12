using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLibrary
{
    public abstract class Cipher
    {
        protected string key;
        protected Cipher(string key)
        {
            this.key = key;
        }

        public abstract string Encrypt(string text);
        public abstract string Decrypt(string text);
    }
}
