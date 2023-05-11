using MediatR;
using ToDoListApi.Dto;

namespace ToDoListApi.Action.User.Commands.Create
{
    public record CreateUserCommand : IRequest<UserDto>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
    }
}
