using Api.Models;
using Api.Models.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapping = new MapperConfiguration(config =>
                {
                    config.CreateMap<ClienteDto, Cliente>().ReverseMap();
                });

            return mapping;
        }
    }
}
