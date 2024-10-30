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
        }

        [TestMethod]
        public void checking_fot_the_correctness_of_DateTime_parsing_with_Exception()
        {
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
        }

        [TestMethod]
        public void checking_fot_the_correctness_of_int_parsing_with_Exception()
        {
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
        }

        [TestMethod]
        public void checking_fot_the_correctness_of_mark_parsing_with_Exception()
        {
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
            var tasks = new Tasks("Иван Иванов", "Контрольная", new DateTime(2024, 09, 16));
            var expected = "Задача   \"Иван Иванов\"   Контрольная   16.09.2024";
            Assert.IsTrue(tasks.Equals(Factory.createObjects(expected)));
        }

        [TestMethod]
        public void checking_fot_the_correctness_of_create_TaskObject_with_Exception()
        {
            Assert.ThrowsException<Exception>(() => Factory.createObjects("Задачи   \"Иван Иванов\"   Контрольная   16.09.2024"));
            Assert.ThrowsException<Exception>(() => Factory.createObjects("Задача   \"Иван Иванов\"   Контрольная"));
            Assert.ThrowsException<Exception>(() => Factory.createObjects("\"Иван Иванов\"   Контрольная   16.09.2024"));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(" "));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(String.Empty));
        }

        [TestMethod]
        public void checking_fot_the_correctness_of_create_MathematicsTaskObject()
        {
            var tasks = new MathematicsTask("Иван Иванов", "Контрольная", new DateTime(2024, 09, 16), 10);
            var expected = "Математика   \"Иван Иванов\"   Контрольная   16.09.2024   10";
            Assert.IsTrue(tasks.Equals(Factory.createObjects(expected)));
        }

        [TestMethod]
        public void checking_fot_the_correctness_of_create_MathematicsTaskObject_with_Exception()
        {
            Assert.ThrowsException<Exception>(() => Factory.createObjects("Математике   \"Иван Иванов\"   Контрольная   16.09.2024   10"));
            Assert.ThrowsException<Exception>(() => Factory.createObjects("Математика   \"Иван Иванов\"   Контрольная   10"));
            Assert.ThrowsException<Exception>(() => Factory.createObjects("\"Иван Иванов\"   Контрольная   16.09.2024   10"));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(" "));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(String.Empty));
        }

        [TestMethod]
        public void checking_fot_the_correctness_of_create_PhysicsTaskObject()
        {
            var tasks = new PhysicsTask("Иван Иванов", "Контрольная", new DateTime(2024, 09, 16), 10, new DateTime(2024, 09, 17));
            var expected = "Физика   \"Иван Иванов\"   Контрольная   16.09.2024   10   17.09.2024";
            Assert.IsTrue(tasks.Equals(Factory.createObjects(expected)));
        }

        [TestMethod]
        public void checking_fot_the_correctness_of_create_PhysicsTaskObject_with_Exception()
        {
            Assert.ThrowsException<Exception>(() => Factory.createObjects("Физике   \"Иван Иванов\"   Контрольная   16.09.2024   10"));
            Assert.ThrowsException<Exception>(() => Factory.createObjects("Физика   \"Иван Иванов\"   Контрольная   10"));
            Assert.ThrowsException<Exception>(() => Factory.createObjects("\"Иван Иванов\"   Контрольная   16.09.2024   10"));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(" "));
            Assert.ThrowsException<Exception>(() => Factory.createObjects(String.Empty));
        }
    }
}