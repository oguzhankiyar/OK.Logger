using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using OK.Logger.SqlServer.EntityFramework;
using System;

namespace OK.Logger.SqlServer.Tests
{
    [TestClass]
    public class SqlServerProviderTests
    {
        [TestMethod]
        public void Insert_ShouldCallRepository_WhenParametersAreValid()
        {
            // Arrange
            ILogRepository logRepository = Substitute.For<ILogRepository>();
            SqlServerProvider provider = new SqlServerProvider(logRepository);

            // Act
            string message = "Test Message";
            object data = new { Arg1 = "Test Arg" };
            DateTime date = DateTime.Now;

            provider.Insert(message, data.ToString(), date);

            // Assert
            logRepository.Received(1)
                         .Add(Arg.Any<LogEntity>());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Insert_ShouldThrowException_WhenMessageParameterIsNotValid()
        {
            // Arrange
            ILogRepository logRepository = Substitute.For<ILogRepository>();
            SqlServerProvider provider = new SqlServerProvider(logRepository);

            // Act
            object data = new { Arg1 = "Test Arg" };
            DateTime date = DateTime.Now;

            provider.Insert(null, data.ToString(), date);
        }

        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Insert_ShouldThrowException_WhenDateParameterIsNotValid()
        {
            // Arrange
            ILogRepository logRepository = Substitute.For<ILogRepository>();
            SqlServerProvider provider = new SqlServerProvider(logRepository);

            // Act
            string message = "Test Message";
            object data = new { Arg1 = "Test Arg" };

            provider.Insert(message, data.ToString(), DateTime.MinValue);
        }
    }
}