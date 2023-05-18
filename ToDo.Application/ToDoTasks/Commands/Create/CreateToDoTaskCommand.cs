using MediatR;
using ToDo.Application.Common.Models;
using ToDo.Domain.Entities;

namespace ToDo.Application.ToDoTasks.Commands.Create
{
    public record CreateToDoTaskCommand : IRequest<ToDoTask>
    {
        public string UserId { get; set; }

        public ToDoTaskDto ToDo { get; set; }

    }
}
