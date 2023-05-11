using AutoMapper;
using ToDoListApi.Action.User.Commands.Create;
using ToDoListApi.Domain;
using ToDoListApi.Dto;

namespace ToDoListApi.Infrastructure.Mapper
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
