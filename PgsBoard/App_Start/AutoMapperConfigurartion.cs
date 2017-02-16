using AutoMapper;
using AutoMapper.Configuration;
using PgsBoard.Data.Entities;
using PgsBoard.ViewModels;

namespace PgsBoard
{
    public static class AutoMapperConfigurartion
    {
        public static IMapper CreateMapper()
        {
            var mapper = ConfigureMapper().CreateMapper();
            return mapper;
        }

        private static MapperConfiguration ConfigureMapper()
        {
            var config = new MapperConfiguration(CreateMappings);
            return config;
        }

        private static void CreateMappings(IMapperConfigurationExpression cfg)
        {

        }
    }
}