// This is a personal academic project. Dear PVS-Studio, please check it.// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
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
        public void create_ProgrammingTaskObject_ReturnsSameProgrammingTaskObject()
        { 
            var tasks = new ProgrammingTask("Иван Иванов", "Контрольная", new DateTime(2024, 09, 16));
            var expected = "Программирование  \"Иван Иванов\"   Контрольная   16.09.2024";
            Assert.AreEqual(tasks, Factory.createObjects(expected));
        }

        [TestMethod]
        public void create_ProgrammingTaskObject_with_Exception()
        {
            string expected = "Программировании   \"Иван Иванов\"   Контрольная   16.09.2024";
            Assert.ThrowsException<Exception>(() => Factory.createObjects(expected));

            //List<string> invalidInputs = new List<string>()
            //{
            //    "Программирование   \"Иван Иванов\"   Контрольная   16.09.2024",
            //    "Программирование  \"Иван Иванов\"   Контрольная   16.09.2024",
            //    "Программировании   \"Иван Иванов\"   Контрольная   16.09.2024",
            //    "Программирование  \"Иван Иванов\"   Контрольная   16.09.2024",
            //};

            //foreach (string item in invalidInputs)
            //{
            //    Assert.ThrowsException<Exception>(() => Factory.createObjects(item));
            //}
        }

        [TestMethod]
        public void сreate_MathematicsTaskObject_ReturnsSameMathematicsTaskObject()
        {
            var tasks = new MathematicsTask("Иван Иванов", "Контрольная", new DateTime(2024, 09, 16), 10);
            var expected = "Математика   \"Иван Иванов\"   Контрольная   16.09.2024   10";
            Assert.AreEqual(tasks, Factory.createObjects(expected));
        }

        [TestMethod]
        public void create_MathematicsTaskObject_with_Exception()
        {
            string expected = "Математике   \"Иван Иванов\"   Контрольная   16.09.2024   10";
            Assert.ThrowsException<Exception>(() => Factory.createObjects(expected));

            //List<string> invalidInputs = new List<string>()
            //{
            //    "Математика   \"Иван Иванов\"   Контрольная   16.09.2024   10",
            //    "Математике   \"Иван Иванов\"   Контрольная   16.09.2024   10",
            //    "Математика   \"Иван Иванов\"   Контрольная   10",
            //    "\"Иван Иванов\"   Контрольная   16.09.2024   10",
            //};

            //foreach (string item in invalidInputs)
            //{
            //    Assert.ThrowsException<Exception>(() => Factory.createObjects(item));
            //}
        }

        [TestMethod]
        public void create_PhysicsTaskObject_ReturnsSamePhysicsTaskObject()
        {
            var tasks = new PhysicsTask("Иван Иванов", "Контрольная", new DateTime(2024, 09, 16), 10, new DateTime(2024, 09, 17));
            var expected = "Физика   \"Иван Иванов\"   Контрольная   16.09.2024   10   17.09.2024";
            Assert.AreEqual(tasks, Factory.createObjects(expected));
        }

        [TestMethod]
        public void create_PhysicsTaskObject_with_Exception()
        {
            string expected = "Физике   \"Иван Иванов\"   Контрольная   16.09.2024   10";
            Assert.ThrowsException<Exception>(() => Factory.createObjects(expected));

            //List<string> invalidInputs = new List<string>()
            //{
            //    "Физика   \"Иван Иванов\"   Контрольная   16.09.2024   10   17.09.2024",
            //    "Физике   \"Иван Иванов\"   Контрольная   16.09.2024   10",
            //    "Физика   \"Иван Иванов\"   Контрольная   10",
            //    "\"Иван Иванов\"   Контрольная   16.09.2024   10",
            //};

            //foreach (string item in invalidInputs)
            //{
            //    Assert.ThrowsException<Exception>(() => Factory.createObjects(item));
            //}
        }
    }
}