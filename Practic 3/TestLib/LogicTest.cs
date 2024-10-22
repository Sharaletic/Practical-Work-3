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
        public void parseDateData()
        {
            Assert.AreEqual(new DateTime(2024, 12, 25), Factory.parseDate("25.12.2024"));
            Assert.ThrowsException<Exception>(() => Factory.parseDate("25.13.2024"));
        }

        [TestMethod]
        public void parseIntData()
        {
            Assert.AreEqual(12, Factory.parseInt("12"));
            Assert.ThrowsException<Exception>(() => Factory.parseInt("anytext"));
        }

        [TestMethod]
        public void parseMarkData()
        {
            Assert.AreEqual(9,8, Factory.parseMark("9,8"));
            Assert.ThrowsException<Exception>(() => Factory.parseMark("11"));
        }

        [TestMethod]
        public void createTaskObject()
        {
            List<string> line1 = new List<string>() { "Задача", "Алексей Иванов", "Контрольная работа", "16.09.2024" };
            Tasks task = Factory.createObjects(line1);
            Assert.AreEqual("Алексей Иванов", task.NameStudent);
            Assert.AreEqual("Контрольная работа", task.TypeOfTask);
            Assert.AreEqual(new DateTime(2024, 09, 16), task.DateGet);

            List<string> line2 = new List<string>() { "Задачи", "Алексей Иванов", "Контрольная работа", "16.09.2024" };
            Assert.ThrowsException<Exception>(() => Factory.createObjects(line2));
        }

        [TestMethod]
        public void createMathematicsTaskObject()
        {
            List<string> line1 = new List<string>() { "Задача по математике", "Алексей Иванов", "Контрольная работа", "16.09.2024", "10" };
            MathematicsTask task = (MathematicsTask)Factory.createObjects(line1);
            Assert.AreEqual("Алексей Иванов", task.NameStudent);
            Assert.AreEqual("Контрольная работа", task.TypeOfTask);
            Assert.AreEqual(new DateTime(2024, 09, 16), task.DateGet);
            Assert.AreEqual(10, task.Mark);

            List<string> line2 = new List<string>() { "Задачи по математике", "Алексей Иванов", "Контрольная работа", "16.09.2024", "10" };
            Assert.ThrowsException<Exception>(() => Factory.createObjects(line2));
        }

        [TestMethod]
        public void createPhysicsTaskObject()
        {
            List<string> line1 = new List<string>() { "Задача по физике", "Алексей Иванов", "Контрольная работа", "16.09.2024", "10", "17.09.2024" };
            PhysicsTask task = (PhysicsTask)Factory.createObjects(line1);
            Assert.AreEqual("Алексей Иванов", task.NameStudent);
            Assert.AreEqual("Контрольная работа", task.TypeOfTask);
            Assert.AreEqual(new DateTime(2024, 09, 16), task.DateGet);
            Assert.AreEqual(10, task.Quantity);
            Assert.AreEqual(new DateTime(2024, 09, 17), task.DateOfCompletion);

            List<string> line2 = new List<string>() { "Задачи по физике", "Алексей Иванов", "Контрольная работа", "16.09.2024", "10" };
            Assert.ThrowsException<Exception>(() => Factory.createObjects(line2));
        }

        [TestMethod]
        public void checkingTheLine()
        {
            Assert.AreEqual(true, Factory.cheeckLine("\"Задача\" \"Алексей Иванов\" \"Контрольная работа\" 16.09.2024"));
            Assert.AreEqual(false, Factory.cheeckLine("\"Задача\" \"Алексей Иванов \"Контрольная работа\" 16.09.2024"));
        }
    }
}
