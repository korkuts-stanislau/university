using System;
using FeistelLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCrypto_3
{
    [TestClass]
    public class TestFeistell
    {
        [TestMethod]
        public void TestPunctuation()
        {
            string w = "AB, CDE";
            FeistrellCipher feistrellCipher = new FeistrellCipher("lime", 16);

            string res = feistrellCipher.Decrypt(feistrellCipher.Encrypt(w));
            Assert.AreEqual(w, res);
        }

        [TestMethod]
        public void TestSentence()
        {
            string w = "APPLE IS A LIE!";
            FeistrellCipher feistrellCipher = new FeistrellCipher("lime", 16);

            string res = feistrellCipher.Decrypt(feistrellCipher.Encrypt(w));
            Assert.AreEqual(w, res);
        }

        [TestMethod]
        public void TestWord()
        {
            string w = "APPLE";
            FeistrellCipher feistrellCipher = new FeistrellCipher("lime", 16);

            string res = feistrellCipher.Decrypt(feistrellCipher.Encrypt(w));
            Assert.AreEqual(w, res);
        }
    }
}

