using CryptoLibrary;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherLibrary
{
    public class MultiplicationCipher : Cipher
    {
        new double[,] key = null;
        public MultiplicationCipher(string key)
            : base(key)
        {
            int n = key.Count(x => x == ' ') + 1;
            int matrixN = Convert.ToInt32(Math.Sqrt(n));

            if (Math.Sqrt(n) * Math.Sqrt(n) != n)
            {
                throw new ArgumentException("Wrong key lenght");
            }

            this.key = new double[matrixN, matrixN];

            string[] keyStr = key.ToUpper().Split();
            for(int i = 0; i < matrixN; i++)
            {
                for(int j = 0; j < matrixN; j++)
                {
                    this.key[i, j] = Convert.ToInt32(keyStr[i * matrixN + j]);
                }
            }

            if (DenseMatrix.OfArray(this.key).Determinant() == 0)
            {
                throw new ArgumentException("Determinant is 0");
            }
        }

        public override string Decrypt(string text)
        {
            List<double> resultNum = new List<double>();
            string result = default;
            double[] symbols = ToDoubleArray(text.Split(' '));
            Matrix<double> textKey = DenseMatrix.OfArray(key).Inverse();

            int n = 0;
            while (n < symbols.Length)
            {
                Vector<double> symbolsVector = DenseVector.Build.Dense(textKey.Column(0).Count);
                Vector<double> resVector;

                for (int i = n, j = 0; i < textKey.Column(0).Count + n; i++, j++)
                {
                    symbolsVector[j] = symbols[i];
                }

                resVector = textKey * symbolsVector;

                for (int i = 0; i < resVector.Count; i++)
                {
                    if (resVector[i] != 0)
                    {
                        resultNum.Add(Math.Round(resVector[i]));
                    }
                }
                n += textKey.Column(0).Count;
            }
            
            for(int i = 0; i < resultNum.Count; i++)
            {
                result += (char)resultNum[i];
            }

            return result;
        }

        public override string Encrypt(string text)
        {
            string result = "";
            var symbols = ToDoubleArray(text.ToUpper());
            Matrix<double> textKey = DenseMatrix.OfArray(key);
            int n = 0;
            while(n < symbols.Length)
            {
                Vector<double> symbolsVector = DenseVector.Build.Dense(textKey.Column(0).Count);
                Vector<double> resVector;
                if (n + textKey.Column(0).Count <= symbols.Length)
                {
                    for(int i = n, j = 0; i < textKey.Column(0).Count + n; i++, j++)
                    {
                        symbolsVector[j] = symbols[i];
                    }

                    resVector = textKey * symbolsVector;

                    for(int i = 0; i < resVector.Count; i++)
                    {
                        if (result.Length == 0)
                        {
                            result += resVector[i];
                        }
                        else
                        {
                            result += " " + resVector[i];
                        }
                    }
                }
                else
                {
                    for (int i = n, j = 0; i < textKey.Column(0).Count + n; i++, j++)
                    {
                        if(i < symbols.Length)
                        {
                            symbolsVector[j] = symbols[i];
                        }
                    }

                    resVector = textKey * symbolsVector;

                    for (int i = 0; i < resVector.Count; i++)
                    {
                        if (result.Length == 0)
                        {
                            result += resVector[i];
                        }
                        else
                        {
                            result += " " + resVector[i];
                        }
                    }
                }
                n += textKey.Column(0).Count;
            }

            return result;
        }

        public double[] ToDoubleArray(string text)
        {
            double[] res = new double[text.Length];

            for(int i = 0; i < text.Length; i++)
            {
                res[i] = Convert.ToInt32(text[i]);
            }
            return res;
        }

        public double[] ToDoubleArray(string[] text)
        {
            double[] res = new double[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                res[i] = Convert.ToInt32(text[i]);
            }
            return res;
        }
    }
}
