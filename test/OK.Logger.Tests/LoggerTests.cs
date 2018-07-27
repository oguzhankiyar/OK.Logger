using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace OK.Logger.Tests
{
    [TestClass]
    public class LoggerTests
    {
        [TestMethod]
        public void Add_ShouldCallProvider_WhenMessageParameterIsValid()
        {
            // Arrange
            ILoggerProvider provider = Substitute.For<ILoggerProvider>();

            // Act
            ILogger logger = new Logger();

            logger.SetProvider(provider);

            logger.Add("Test Message");

            // Assert
            provider.Received(1)
                    .Insert(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<DateTime>());
        }
    }
}
