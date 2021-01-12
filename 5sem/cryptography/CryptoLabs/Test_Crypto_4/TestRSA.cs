using System;
using CryptoLabs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Crypto_4
{
    [TestClass]
    public class TestRSA
    {
        [TestMethod]
        public void TestPunctuation()
        {
            string w = "AB, CDE";
            RSACipher rsaCipher = new RSACipher();

            string res = rsaCipher.Decrypt(rsaCipher.Encrypt(w));
            Assert.AreEqual(w, res);
        }

        [TestMethod]
        public void TestSentence()
        {
            string w = "APPLE IS A LIE!";
            RSACipher rsaCipher = new RSACipher();

            string res = rsaCipher.Decrypt(rsaCipher.Encrypt(w));
            Assert.AreEqual(w, res);
        }

        [TestMethod]
        public void TestWord()
        {
            string w = "APPLE";
            RSACipher rsaCipher = new RSACipher();

            string res = rsaCipher.Decrypt(rsaCipher.Encrypt(w));
            Assert.AreEqual(w, res);
        }
    }
}
