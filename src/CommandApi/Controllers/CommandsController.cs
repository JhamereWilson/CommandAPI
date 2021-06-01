using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandApi.DAL;
using CommandApi.Models;
using CommandApi.DTO;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;


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

        [HttpPost]
        public ActionResult<CommandReadDTO> CreateCommand(CommandCreateDTO commandCreateDTO)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDTO);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDTO = _mapper.Map<CommandReadDTO>(commandModel);
            return CreatedAtRoute(nameof(GetCommandById),
            new { Id = commandReadDTO.Id }, commandReadDTO
            );

        }

        [HttpPatch]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDTO> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            var commandToPatch = _mapper.Map<CommandUpdateDTO>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(commandToPatch, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();



        }


    }


}