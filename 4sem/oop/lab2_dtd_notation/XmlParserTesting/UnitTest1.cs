using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubjectLib;
using XmlParserLib;

namespace XmlParserTesting
{
    [TestClass]
    public class UnitTest1
    {
        Subjects subjects;
        [TestMethod]
        public void TestMethod1()
        {
            subjects = new Subjects();
            XmlParser.ReadFromXmlFile(subjects);
            Assert.AreEqual(subjects[2].ToString(), "Дисциплина Базы данных, часы 120/60, " +
                "тип контроля Экзамен, преподаватель: Асенчик Олег Даниилович");
        }
    }
}
