using MediatR;
using System.ComponentModel.DataAnnotations;
using ToDoListApi.Dto;

namespace ToDoListApi.Action.ToDoTask.Commands.Create
{
    public record CreateToDoTaskCommand:IRequest<ToDoTaskDto>
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string TaskDate { get; set; }

    }
}
