using AutoMapper;
using CommandApi.DTO;
using CommandApi.Models;

namespace CommandApi.Models
{
    public class CommandsProfile : Profile {
        
        public CommandsProfile() {
            CreateMap<Command,CommandReadDTO>();
        }
    }

}
