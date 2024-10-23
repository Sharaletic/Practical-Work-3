using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Logic;
using System.Collections.Generic;

namespace TestLib
{
    [TestClass]
    public class LogicTest
    {
        [TestMethod]
        public void checking_fot_the_correctness_of_DateTime_parsing()
        {
            Assert.AreEqual(new DateTime(2024, 12, 25), Factory.parseDate("25.12.2024"));
            Assert.AreEqual(new DateTime(2024, 12, 25), Factory.parseDate("25,12,2024"));
            Assert.AreEqual(new DateTime(2024, 12, 25), Factory.parseDate("25/12/2024"));
            Assert.AreEqual(new DateTime(2024, 12, 25), Factory.parseDate("25 12 2024"));
            Assert.ThrowsException<Exception>(() => Factory.parseDate("00.00.0000"));
            Assert.ThrowsException<Exception>(() => Factory.parseDate("25.13.2024"));
            Assert.ThrowsException<Exception>(() => Factory.parseDate("25122024"));
            Assert.ThrowsException<Exception>(() => Factory.parseDate("sometext"));
            Assert.ThrowsException<Exception>(() => Factory.parseDate("25.12.2024 sometext"));
            Assert.ThrowsException<Exception>(() => Factory.parseDate("sometext 25.12.2024"));
            Assert.ThrowsException<Exception>(() => Factory.parseDate(""));
            Assert.ThrowsException<Exception>(() => Factory.parseDate(" "));
        }

        [TestMethod]
        public void checking_fot_the_correctness_of_int_parsing()
        {
            Assert.AreEqual(123, Factory.parseInt("123"));
            Assert.AreEqual(-123, Factory.parseInt("-123"));
            Assert.AreEqual(0, Factory.parseInt("0"));
            Assert.ThrowsException<Exception>(() => Factory.parseInt("12,3"));
            Assert.ThrowsException<Exception>(() => Factory.parseInt("12.3"));
            Assert.ThrowsException<Exception>(() => Factory.parseInt("12 3"));
            Assert.ThrowsException<Exception>(() => Factory.parseInt("sometext"));
            Assert.ThrowsException<Exception>(() => Factory.parseInt("123 sometext"));
            Assert.ThrowsException<Exception>(() => Factory.parseInt("sometext 123"));
            Assert.ThrowsException<Exception>(() => Factory.parseInt(""));
            Assert.ThrowsException<Exception>(() => Factory.parseInt(" "));
        }

        [TestMethod]
        public void checking_fot_the_correctness_of_mark_parsing()
        {
            Assert.AreEqual(9,8, Factory.parseMark("9,9"));
            Assert.AreEqual(0, Factory.parseMark("0"));
            Assert.AreEqual(10, Factory.parseMark("10"));
            Assert.ThrowsException<Exception>(() => Factory.parseMark("12"));
            Assert.ThrowsException<Exception>(() => Factory.parseMark("-5"));
            Assert.ThrowsException<Exception>(() => Factory.parseMark("9.8"));
            Assert.ThrowsException<Exception>(() => Factory.parseMark("sometext"));
            Assert.ThrowsException<Exception>(() => Factory.parseMark("5 sometext"));
            Assert.ThrowsException<Exception>(() => Factory.parseMark("sometext 5"));
            Assert.ThrowsException<Exception>(() => Factory.parseMark(""));
            Assert.ThrowsException<Exception>(() => Factory.parseMark(" "));
        }

        [TestMethod]
        public void checking_fot_the_correctness_of_create_TaskObject()
        {
            List<string> expected = new List<string>() { "Задача", "Алексей Иванов", "Контрольная работа", "16.09.2024" };
            Tasks task = Factory.createObjects(expected);
            Assert.AreEqual("Алексей Иванов", task.NameStudent);
            Assert.AreEqual("Контрольная работа", task.TypeOfTask);
            Assert.AreEqual(new DateTime(2024, 09, 16), task.DateGet);

            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { "Задачи", "Алексей Иванов", "Контрольная работа", "16.09.2024" }));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { "Алексей Иванов", "Контрольная работа", "16.09.2024" }));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { "Задача", "Алексей Иванов", "Контрольная работа" }));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { "Задача" }));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { "Задача", "", "", "" }));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { "Задача", " ", " ", " " }));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { "" }));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { " " }));
        }

        [TestMethod]
        public void checking_fot_the_correctness_of_create_MathematicsTaskObject()
        {
            List<string> expected = new List<string>() { "Задача по математике", "Алексей Иванов", "Контрольная работа", "16.09.2024", "10" };
            MathematicsTask task = (MathematicsTask)Factory.createObjects(expected);
            Assert.AreEqual("Алексей Иванов", task.NameStudent);
            Assert.AreEqual("Контрольная работа", task.TypeOfTask);
            Assert.AreEqual(new DateTime(2024, 09, 16), task.DateGet);
            Assert.AreEqual(10, task.Mark);

            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { "Задачи по математике", "Алексей Иванов", "Контрольная работа", "16.09.2024", "10" }));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { "Алексей Иванов", "Контрольная работа", "16.09.2024", "10" }));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { "Задача по математике", "Алексей Иванов", "Контрольная работа", "16.09.2024" }));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { "Задача по математике" }));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { "Задача по математике", "", "", "", "" }));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { "Задача по математике", " ", " ", " ", " " }));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { "" }));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { " " }));
        }

        [TestMethod]
        public void checking_fot_the_correctness_of_create_PhysicsTaskObject()
        {
            List<string> expected = new List<string>() { "Задача по физике", "Алексей Иванов", "Контрольная работа", "16.09.2024", "10", "17.09.2024" };
            PhysicsTask task = (PhysicsTask)Factory.createObjects(expected);
            Assert.AreEqual("Алексей Иванов", task.NameStudent);
            Assert.AreEqual("Контрольная работа", task.TypeOfTask);
            Assert.AreEqual(new DateTime(2024, 09, 16), task.DateGet);
            Assert.AreEqual(10, task.Quantity);
            Assert.AreEqual(new DateTime(2024, 09, 17), task.DateOfCompletion);

            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { "Задачи по физике", "Алексей Иванов", "Контрольная работа", "16.09.2024", "10" }));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { "Алексей Иванов", "Контрольная работа", "16.09.2024", "10" }));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { "Задача по физике", "Алексей Иванов", "Контрольная работа", "16.09.2024" }));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { "Задача по физике" }));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { "Задача по физике", "", "", "", "" }));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { "Задача по физике", " ", " ", " ", " " }));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { "" }));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(new List<string>() { " " }));
        }

        [TestMethod]
        public void checking_fot_the_correctness_of_split_line()
        {
            CollectionAssert.AreEqual(new List<string> { "Задача", "Алексей Иванов", "Контрольная работа", "16.09.2024" }, Factory.splitLine("\"Задача\" \"Алексей Иванов\" \"Контрольная работа\" 16.09.2024"));
            Assert.ThrowsException<Exception>(() => Factory.splitLine("\"Задача\" \"Алексей Иванов \"Контрольная работа\" 16.09.2024"));
            Assert.ThrowsException<Exception>(() => Factory.splitLine("\"Задача\" Алексей Иванов \"Контрольная работа\" 16.09.2024"));
            Assert.ThrowsException<Exception>(() => Factory.splitLine("Задача Алексей Иванов Контрольная работа 16.09.2024"));
            Assert.ThrowsException<Exception>(() => Factory.splitLine(string.Empty));
            Assert.ThrowsException<Exception>(() => Factory.splitLine(""));
            Assert.ThrowsException<Exception>(() => Factory.splitLine(" "));
        }
    }
}
