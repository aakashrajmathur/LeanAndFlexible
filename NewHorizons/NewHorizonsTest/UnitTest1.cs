using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewHorizons;

namespace NewHorizonsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestCanary()
        {
            Study study = new Study();
            Assert.IsNotNull(study.parts);
        }

    }
}
