using API.Models;
using API.Models.Dto;
using AutoMapper;

namespace API
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Unitx, UnitxDto>().ReverseMap();
            CreateMap<Unitx, UnitxCreateDto>().ReverseMap();
            CreateMap<Unitx, UnitxUpdateDto>().ReverseMap();
        }
    }
}
