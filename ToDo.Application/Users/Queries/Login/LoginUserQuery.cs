using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Application.Users.Queries.Login
{
    public record LoginUserQuery : IRequest<string>
    {
        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
