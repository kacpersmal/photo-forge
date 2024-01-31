using AutoMapper;

using PhotoForge.Application.Features.Users.Dto;
using PhotoForge.Core.Features.Users;

namespace PhotoForge.Application.Features.Users;

public class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<User, UserDto>()
            .ForMember(dto => dto.Email, opt => opt.MapFrom(x => x.Email.Address))
            .ForMember(dto => dto.FullName, opt => opt.MapFrom(x => x.FullName.Name))
            ;
    }
}