using MediatR;
using System.ComponentModel.DataAnnotations;
using ToDoListApi.Action.User.Vm;

namespace ToDoListApi.Action.User.Queries.Login
{
    public record LoginUserQuery : IRequest<UserLoginVm>
    {
        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
