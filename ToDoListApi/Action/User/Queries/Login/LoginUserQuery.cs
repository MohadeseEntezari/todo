using MediatR;
using ToDoListApi.Action.User.Vm;

namespace ToDoListApi.Action.User.Queries.Login
{
    public record LoginUserQuery : IRequest<UserLoginVm>
    {
        public string Mobile { get; set; }
        public string Password { get; set; }
    }
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, UserLoginVm>
    {
        public LoginUserQueryHandler()
        {

        }

        public Task<UserLoginVm> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
