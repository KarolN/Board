using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using PgsBoard.Data.Entities;
using PgsBoard.Dtos;
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
            cfg.CreateMap<Cart, CartViewModel>();
            cfg.CreateMap<List, ListViewModel>()
                .ForMember(x => x.CreateCartDto, opt => opt.MapFrom(o => new CreateCartDto() {ListId = o.Id}))
                .ForMember(x => x.Carts, opt => opt.MapFrom(s => s.Carts.OrderBy(c => c.Position)));
            cfg.CreateMap<Board, ShowBoardViewModel>()
                .ForMember(x => x.CreateListDto, opt => opt.MapFrom(o => new CreateListDto() {BoardId = o.Id}));
        }
    }
}