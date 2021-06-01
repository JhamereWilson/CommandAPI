using System.Collections.Generic;
using CommandApi.Models;

namespace CommandApi.DAL
{
    public interface ICommandApiRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command command);
        void UpdateCommand(Command command);
        void DeleteCommand(Command command);
    }
}