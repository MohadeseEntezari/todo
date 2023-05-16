using MediatR;
using System.ComponentModel.DataAnnotations;
using ToDo.Application.Common.Models;

namespace ToDo.Application.Users.Commands.Create
{
    public record CreateUserCommand : IRequest<UserDto>
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
