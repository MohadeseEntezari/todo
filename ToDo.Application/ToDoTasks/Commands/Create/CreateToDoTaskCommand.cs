using MediatR;
using System.ComponentModel.DataAnnotations;
using ToDo.Application.Common.Models;

namespace ToDo.Application.ToDoTasks.Commands.Create
{
    public record CreateToDoTaskCommand : IRequest<ToDoTaskDto>
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string TaskDate { get; set; }

    }
}
