using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JenkinsMSBuildExample;

namespace JenkinsMSBuildExampleTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSayHello()
        {
            var program = new Program();
            Assert.AreEqual(program.SayHello(), "Hello");
        }
    }
}
