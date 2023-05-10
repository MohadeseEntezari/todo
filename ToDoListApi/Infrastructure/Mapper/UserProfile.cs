using AutoMapper;
using ToDoListApi.Action.User.Commands.Create;
using ToDoListApi.Domain;

namespace ToDoListApi.Infrastructure.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserCommand, User>();
        }
    }
}
