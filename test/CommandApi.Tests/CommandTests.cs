using System;
using Xunit;
using CommandApi.Models;

namespace CommandApi.Tests
{
    public class CommandTests : IDisposable
    {
        Command testCommand;
        public CommandTests()
        {
            testCommand = new Command
            {
                HowTo = "Do Something",
                Platform = "Some platform",
                CommandLine = "Some commandline"
            };
        }

        public void Dispose()
        {
            testCommand = null;
        }
        [Fact]
        public void CanChangeHowTo()
        {
            //Arrange 
            var testCommand = new Command
            {
                HowTo = "Do something awesome",
                Platform = "xUnit",
                CommandLine = "dotnet test"
            };

            //Act 
            testCommand.HowTo = "Execute Unit Tests";

            //Assert

            Assert.Equal("Execute Unit Tests", testCommand.HowTo);
        }
    }

}