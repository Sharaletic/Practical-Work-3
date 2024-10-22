using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Logic;

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
    }
}
