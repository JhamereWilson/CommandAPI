using System.Collections.Generic;
using CommandApi.Models;

namespace CommandApi.Data
{
    public class MockCommandApiRepo : ICommandApiRepo
    {
        public void CreateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command {
                    Id = 1,
                    HowTo="How to 1",
                    CommandLine="ComandLine 1",
                    Platform=".Net Core EF"
                },
                new Command {
                    Id = 2,
                    HowTo="How to 2",
                    CommandLine="ComandLine 1",
                    Platform=".Net Core EF"
                },
                new Command {
                    Id = 3,
                    HowTo="How to 3",
                    CommandLine="ComandLine 1",
                    Platform=".Net Core EF"
                },
        };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command
            {
                Id = 1,
                HowTo = "How To 1",
                CommandLine = "Command Line 1",
                Platform = ".Net Core EF",
            };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }
    }
}