using MediatR;
using System.ComponentModel.DataAnnotations;
using ToDoListApi.Dto;

namespace ToDoListApi.Action.User.Commands.Create
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
