using System;
using CipherLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCrypto_2
{
    [TestClass]
    public class TestVigenere
    {
        [TestMethod]
        public void TestPunctuation()
        {
            string w = "ab, cde";
            VegenereCipher vigenereCipher = new VegenereCipher("apple");

            string res = vigenereCipher.Decrypt(vigenereCipher.Encrypt(w));
            Assert.AreEqual(w, res);
        }

        [TestMethod]
        public void TestSentence()
        {
            string w = "cake is a lie!";
            VegenereCipher vigenereCipher = new VegenereCipher("lime");

            string res = vigenereCipher.Decrypt(vigenereCipher.Encrypt(w));
            Assert.AreEqual(w, res);
        }

        [TestMethod]
        public void TestWord()
        {
            string w = "apple";
            VegenereCipher vigenereCipher = new VegenereCipher("banana");

            string res = vigenereCipher.Decrypt(vigenereCipher.Encrypt(w));
            Assert.AreEqual(w, res);
        }
    }
}
