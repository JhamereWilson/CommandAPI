using AutoMapper;
using CommandApi.DTO;
using CommandApi.Models;

namespace CommandApi.Models
{
    public class CommandsProfile : Profile
    {

        public CommandsProfile()
        {

            //Source 
            CreateMap<Command, CommandReadDTO>();
            CreateMap<CommandCreateDTO, Command>();
            CreateMap<CommandUpdateDTO, Command>();
            CreateMap<Command, CommandUpdateDTO>();
        }
    }

}
