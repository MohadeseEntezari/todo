using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ToDoListApi.Action.ToDoTask.Commands.Update
{
    public record UpdateToDoTaskCommand : IRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
       
        [Required]
        public string Title { get; set; }

        [Required]
        public string ToDoDate { get; set; }
    }
}
