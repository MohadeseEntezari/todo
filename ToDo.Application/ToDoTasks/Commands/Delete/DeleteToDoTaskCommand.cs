using MediatR;

namespace ToDo.Application.ToDoTasks.Commands.Delete
{
    public record DeleteToDoTaskCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
