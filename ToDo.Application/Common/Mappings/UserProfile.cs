using AutoMapper;
using ToDo.Application.Common.Models;
using ToDo.Application.Users.Commands.Create;
using ToDo.Domain.Entities;

namespace ToDo.Application.Common.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            CreateMap<CreateUserCommand, User>();
            CreateMap<User, UserDto>().ReverseMap();

        }
    }
}
