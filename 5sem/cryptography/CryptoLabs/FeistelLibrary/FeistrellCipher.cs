using CryptoLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace FeistelLibrary
{
    public class FeistrellCipher : Cipher
    {
        int roundsNum;
        new string key;

        string BigIntToString(BigInteger number)
        {
            var bytes = number.ToByteArray();

        }

        public FeistrellCipher(string key, int roundsNum)
            : base(key)
        {
            this.key = "";
            this.roundsNum = roundsNum;

            var tmpKey = Encoding.ASCII.GetBytes(key);
            for (int i = 0; i < tmpKey.Length; i++)
            {
                this.key += tmpKey[i] + " ";
            }
        }

        public override string Decrypt(string text)
        {
            var values = text.Split(' ').ToList();
            values.RemoveAll(x => x.Length == 0);
            string result = default;

            for (int n = 0; n < values.Count; n += 2)
            {
                result += DecryptText(values[n] + " " + values[n + 1]);
            }

            return result.Trim();
        }

        public override string Encrypt(string text)
        {
            string result = default;
            for (int n = 0; n < text.Length; n += 4)
            {
                if (n + 4 < text.Length)
                {
                    result += EncryptText(text.Substring(n, 4));
                }
                else
                {
                    var tmpText = text.Substring(n, text.Length - n);
                    while (tmpText.Length < 4)
                    {
                        tmpText += " ";
                    }
                    result += EncryptText(tmpText);
                }
            }

            return result;
        }

        private string DecryptText(string text)
        {
            string tmpL = text.Split(' ')[0];
            string tmpR = text.Split(' ')[1];

            Int64 l = Int64.Parse(tmpL);
            Int64 r = Int64.Parse(tmpR);

            for (int i = roundsNum - 1; i >= 0; i--)
            {
                if (i < roundsNum - 1)
                {
                    l = ROR(r, GetKeyShift(i)) ^ l;
                    var t = l;
                    l = r;
                    r = t;
                }
                else
                {
                    r = r ^ ROR(l, GetKeyShift(i));
                }
            }

            var bitesString = IntToString(l) + IntToString(r);
            bool[] boolArray = new bool[bitesString.Length];
            for (int i = 0; i < boolArray.Length; i++)
            {
                if (bitesString[i] == '0')
                {
                    boolArray[i] = false;
                }
                else
                {
                    boolArray[i] = true;
                }
            }

            BitArray bit = new BitArray(boolArray);
            var bytes = ConvertToByte(bit);

            return Encoding.ASCII.GetString(bytes);
        }

        private string EncryptText(string text)
        {
            BitArray bitArray = GetBitesFromString(text);
            bool[] ret = new bool[bitArray.Length];
            bitArray.CopyTo(ret, 0);

            var l = CopySlice(bitArray, 0, bitArray.Length / 2);
            var r = CopySlice(bitArray, bitArray.Length / 2, bitArray.Length / 2);

            var bl = GetBigInt(l);
            var br = GetBigInt(r);

            for (int i = 0; i < roundsNum; i++)
            {
                if (i < roundsNum - 1)
                {
                    var t = bl;
                    bl = br ^ (ROR(bl, GetKeyShift(i)));
                    br = t;
                }
                else
                {
                    br = br ^ (ROR(bl, GetKeyShift(i)));
                }
            }

            return bl.ToString() + " " + br.ToString() + " ";
        }

        string IntToString(Int64 number)
        {
            string result = "";
            if (number.ToString().Length < 16)
            {
                for (int i = 0; i < 16 - number.ToString().Length; i++)
                {
                    result += "0";
                }
            }
            result += number.ToString();
            return result;
        }

        int GetKeyShift(int roundsNum)
        {
            List<string> values = key.Split(' ').ToList();
            values.RemoveAll(x => x.Length == 0);
            if (values.Count > roundsNum)
            {
                return Convert.ToInt32(values[roundsNum]);
            }
            else
            {
                return Convert.ToInt32(values[roundsNum % values.Count]);
            }
        }

        Int64 GetBigInt(BitArray bitArray)
        {
            string array = "";
            for (int i = 0; i < bitArray.Length; i++)
            {
                if (bitArray[i])
                {
                    array += "1";
                }
                else
                {
                    array += "0";
                }
            }

            return Int64.Parse(array);
        }

        public BitArray CopySlice(BitArray source, int offset, int length)
        {
            BitArray ret = new BitArray(length);
            for (int i = 0; i < length; i++)
            {
                ret[i] = source[offset + i];
            }
            return ret;
        }

        byte[] ConvertToByte(BitArray bits)
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }

        BitArray GetBitesFromString(string str)
        {
            return new BitArray(Encoding.ASCII.GetBytes(str));
        }

        Int64 ROR(Int64 number, int shift)
        {
            shift %= 15;
            return ((number >> shift) | (number << (16 - shift)));
        }
    }
}
