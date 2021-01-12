using System;
using CipherLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCrypto_2
{
    [TestClass]
    public class TestPermutation
    {
        [TestMethod]
        public void TestPunctuation()
        {
            string w = "ab, cde";
            PermutationCipher permutationCipher = new PermutationCipher("3 1 2 4 5");

            string res = permutationCipher.Decrypt(permutationCipher.Encrypt(w));
            Assert.AreEqual(w, res);
        }

        [TestMethod]
        public void TestSentence()
        {
            string w = "apple is a lie!";
            PermutationCipher permutationCipher = new PermutationCipher("3 1 2 4 5");

            string res = permutationCipher.Decrypt(permutationCipher.Encrypt(w));
            Assert.AreEqual(w, res);
        }

        [TestMethod]
        public void TestWord()
        {
            string w = "apple";
            PermutationCipher permutationCipher = new PermutationCipher("3 1 2 4 5");

            string res = permutationCipher.Decrypt(permutationCipher.Encrypt(w));
            Assert.AreEqual(w, res);
        }
    }
}
