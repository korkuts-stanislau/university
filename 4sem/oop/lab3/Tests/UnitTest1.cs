using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DecoratorLib;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace StreamDecoratorTestProject
{
    [TestClass]
    public class StreamDecoratorUnitTest
    {
        [TestMethod]
        public void TestMethodFileStream()
        {
            byte[] lastNBytes;
            using (FileStream fileStream = new FileStream(@"D:\korkuts-itp21-oop\lab3\WriteFile.txt", FileMode.Create))
            {
                using (StreamGetLastNDecorator stream = new StreamGetLastNDecorator(fileStream))
                {
                    lastNBytes = stream.Write(Encoding.UTF8.GetBytes("Hello, world"), 5);
                }
            }
            CollectionAssert.AreEqual(Encoding.UTF8.GetBytes("world"), lastNBytes);
        }

        [TestMethod]
        public void TestMethodMemoryStream()
        {
            byte[] lastNBytes;
            using (MemoryStream fileStream = new MemoryStream())
            {
                using (StreamGetLastNDecorator stream = new StreamGetLastNDecorator(fileStream))
                {
                    lastNBytes = stream.Write(Encoding.UTF8.GetBytes("Hello, world"), 5);
                }
            }
            CollectionAssert.AreEqual(Encoding.UTF8.GetBytes("world"), lastNBytes);
        }

        [TestMethod]
        public void TestMethodBufferedStream()
        {
            byte[] lastNBytes;
            using (FileStream fileStream = new FileStream(@"D:\korkuts-itp21-oop\lab3\WriteFile.txt", FileMode.Open))
            {
                using (BufferedStream bufferedStream = new BufferedStream(fileStream))
                {
                    using (StreamGetLastNDecorator stream = new StreamGetLastNDecorator(bufferedStream))
                    {
                        lastNBytes = stream.Write(Encoding.UTF8.GetBytes("Hello, world"), 5);
                    }
                }
            }
            CollectionAssert.AreEqual(Encoding.UTF8.GetBytes("world"), lastNBytes);
        }
    }
}
