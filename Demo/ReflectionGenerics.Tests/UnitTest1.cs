using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GenericsАndReflection;
using GenericsАndReflection.Container;


namespace ReflectionGenerics.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Resolve_Types()
        {
            //Arrange
            var ioc = new Container();
            ioc.For<ILogger>().Use<SqlServerLogger>();

            //Act
            var logger = ioc.Resolve<ILogger>();

            //Assert
            Assert.AreEqual(typeof(SqlServerLogger), logger.GetType());
        }

        [TestMethod]
        public void Can_Resolve_Types_Without_DefaultCtor()
        {
            //Arrange
            var ioc = new Container();
            ioc.For<ILogger>().Use<SqlServerLogger>();
            ioc.For<IRepository<Employee>>().Use<SqlRepository<Employee>>();

            //Act
            var repo = ioc.Resolve<IRepository<Employee>>();

            //Assert
            Assert.AreEqual(typeof(SqlRepository<Employee>), repo.GetType());
        }
    }
}
