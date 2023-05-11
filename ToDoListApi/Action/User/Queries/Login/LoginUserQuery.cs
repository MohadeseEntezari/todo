using MediatR;
using ToDoListApi.Action.User.Vm;

namespace ToDoListApi.Action.User.Queries.Login
{
    public record LoginUserQuery : IRequest<UserLoginVm>
    {
        public string Mobile { get; set; }
        public string Password { get; set; }
    }
}
