using System;
using dl = DictionaryLib;
using System.Collections.Generic;
using SubjectLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test
    {
        bool CollectionsCompare<TKey, TValue>(dl.Dictionary<TKey, TValue> myDict, Dictionary<TKey, TValue> defDict)
        {
            if (myDict.Count != defDict.Count)
                return false;
            foreach(TKey key in defDict.Keys)
            {
                if (!myDict[key].Equals(defDict[key]))
                    return false;
            }
            return true;
        }
        [TestMethod]
        public void StringDoubleCheck()
        {
            Dictionary<string, double> defDict = new Dictionary<string, double>();
            dl.Dictionary<string, double> myDict = new dl.Dictionary<string, double>();
            defDict.Add("один", 1);
            defDict.Add("два", 2);
            myDict.Add("один", 1);
            myDict.Add("два", 2);
            defDict.Remove("один");
            myDict.Remove("один");
            Assert.IsTrue(CollectionsCompare<string, double>(myDict, defDict));
        }
        [TestMethod]
        public void TestContains()
        {
            Dictionary<string, double> defDict = new Dictionary<string, double>();
            dl.Dictionary<string, double> myDict = new dl.Dictionary<string, double>();
            defDict.Add("один", 1);
            defDict.Add("два", 2);
            myDict.Add("один", 1);
            myDict.Add("два", 2);
            Assert.IsTrue(myDict.Contains("один") && defDict.ContainsKey("два"));
        }
        [TestMethod]
        public void TestCopyTo()
        {
            dl.Dictionary<string, double> myDict = new dl.Dictionary<string, double>();
            myDict.Add("один", 1);
            myDict.Add("два", 2);
            myDict.Add("три", 3);
            myDict.Add("четыре", 4);
            dl.KeyValue<string, double>[] keyValues = new dl.KeyValue<string, double>[2];
            myDict.CopyTo(keyValues, 2);
            dl.KeyValue<string, double>[] expected = new dl.KeyValue<string, double>[]
                                                                { new dl.KeyValue<string, double>("три", 3),
                                                                new dl.KeyValue<string, double>("четыре", 4) };
            bool flag = true;
            for(int i = 0; i < keyValues.Length; i++)
            {
                if (!keyValues[i].Equals(expected))
                    flag = false;
            }
            Assert.IsTrue(flag);
        }
    }
}
