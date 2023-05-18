using MediatR;
using ToDo.Application.Common.Models;

namespace ToDo.Application.ToDoTasks.Commands.Update
{
    public record UpdateToDoTaskCommand : IRequest
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public ToDoTaskDto ToDo { get; set; }
    }
}
