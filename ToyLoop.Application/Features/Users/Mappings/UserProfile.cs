using AutoMapper;
using ToyLoop.Application.Features.Users.DTOs;
using ToyLoop.Domain.Entities;

namespace ToyLoop.Application.Features.Users.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location.City + " / " + src.Location.District));
        }
    }
}