using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GenericsАndReflection.Container;


namespace ReflectionGenerics.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var ioc = new Container();
            ioc.For<ILogger>().Use<SqlServerLogger>();

            //Act
            var logger = ioc.Resolve<ILogger>();

            //Assert
            Assert.AreEqual(typeof(SqlServerLogger), logger.GetType());
        }
    }
}
