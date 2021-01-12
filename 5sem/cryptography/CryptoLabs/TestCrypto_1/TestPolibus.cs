using CryptoLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCrypto_1
{
    [TestClass]
    public class TestPolibus
    {
        public PolibiusCipher polibiusCipher = new PolibiusCipher("abcde");
        [TestMethod]
        public void TestOneWord()
        {
            string startWord, encodedWord;
            for (int i = 0; i < 1000; i++)
            {

                startWord = RandomGenerator.RandomString(10).ToLower();

                encodedWord = polibiusCipher.Encrypt(startWord);
                Assert.AreEqual(startWord, polibiusCipher.Decrypt(encodedWord));
            }
        }

        [TestMethod]
        public void TestSentece()
        {
            string startSentece = default, encodedSentece;
            for (int i = 0; i < 1000; i++)
            {
                startSentece = default;
                for (int j = 0; j < 5; j++)
                {
                    if(j != 4)
                    {
                        startSentece += RandomGenerator.RandomString(10).ToLower() + " ";
                    }
                    else
                    {
                        startSentece += RandomGenerator.RandomString(10).ToLower();
                    }
                }
                encodedSentece = polibiusCipher.Encrypt(startSentece);

                Assert.AreEqual(startSentece, polibiusCipher.Decrypt(encodedSentece));
            }
        }
    }
}
