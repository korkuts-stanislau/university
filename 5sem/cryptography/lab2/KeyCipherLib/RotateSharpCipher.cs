using System;
using System.Collections.Generic;
using System.Text;

namespace KeyCipherLib
{
    public class RotateSharpCipher : ICipher
    {
        public string Decode(string textToDecode)
        {
            return new CaesarForCheat().Decode(textToDecode, "Sharp");
        }

        public string Encode(string textToEncode)
        {
            return new CaesarForCheat().Encode(textToEncode, "Sharp");
        }
    }
}
