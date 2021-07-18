using Api.Models;
using Api.Models.DTO;
using AutoMapper;

namespace Api
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapping = new MapperConfiguration(config =>
                {
                    config.CreateMap<ClienteDto, Cliente>().ReverseMap();
                    config.CreateMap<UserDto, User>().ReverseMap();
                });

            return mapping;
        }
    }
}
