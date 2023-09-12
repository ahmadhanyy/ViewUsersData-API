using AutoMapper;
using Task2.Dtos;
using Task2.Models;

namespace Task2
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserDetailesDto>().ReverseMap();
        }
    }
}
