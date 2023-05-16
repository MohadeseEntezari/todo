using MediatR;
using System.ComponentModel.DataAnnotations;
using ToDo.Application.Users.Vm;

namespace ToDo.Application.Users.Queries.Login
{
    public record LoginUserQuery : IRequest<UserLoginVm>
    {
        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
