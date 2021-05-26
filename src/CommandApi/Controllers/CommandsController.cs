using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandApi.Data;
using CommandApi.Models;

namespace CommandApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandApiRepo _repository;
        public CommandsController(ICommandApiRepo repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(commandItems); // returns http 200 result code and passes back result json command data
        }
        [HttpGet]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            return Ok(commandItem);
        }
    }


}