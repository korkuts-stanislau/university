using System;
using CryptoLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCrypto_1
{
    [TestClass]
    public class TestCaesar
    {
        public CeasarCipher ceasarCipher = new CeasarCipher("12");
        [TestMethod]
        public void TestOneWord()
        {
            string startWord, encodedWord;
            for(int i = 0; i < 1000; i++)
            {
                startWord = RandomGenerator.RandomString(10).ToLower();
                encodedWord = ceasarCipher.Encrypt(startWord);

                Assert.AreEqual(startWord, ceasarCipher.Decrypt(encodedWord));
            }
        }

        [TestMethod]
        public void TestSentece()
        {
            string startSentece = default, encodedSentece;
            for (int i = 0; i < 1000; i++)
            {
                startSentece = default;
                for(int j = 0; j < 5; j++)
                {
                    startSentece += RandomGenerator.RandomString(10).ToLower() + " ";
                }
                encodedSentece = ceasarCipher.Encrypt(startSentece);

                Assert.AreEqual(startSentece, ceasarCipher.Decrypt(encodedSentece));
            }
        }
    }
}
