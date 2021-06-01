using System;
using System.Collections.Generic;
using System.Linq;
using CommandApi.Models;

namespace CommandApi.DAL
{
    public class SqlCommandApiRepo : ICommandApiRepo
    {
        private readonly CommandContext _context;

        public SqlCommandApiRepo(CommandContext context)
        {
            _context = context;
        }
        public void CreateCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            _context.CommandItems.Add(command);
        }

        public void DeleteCommand(Command command)
        {
            if (command == null)
            {

                throw new ArgumentNullException(nameof(command));
            }
            _context.CommandItems.Remove(command);
        }

        public IEnumerable<Command> GetAllCommands()
        {

            return _context.CommandItems.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.CommandItems.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }
    }
}