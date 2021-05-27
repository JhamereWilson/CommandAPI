using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandApi.Data;
using CommandApi.Models;
using CommandApi.DTO;
using AutoMapper;


namespace CommandApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandApiRepo _repository;
        private readonly IMapper _mapper;
        public CommandsController(ICommandApiRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDTO>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commandItems)); // returns http 200 result code and passes back result json command data
        }
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDTO> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CommandReadDTO>(commandItem));
        }
    }


}