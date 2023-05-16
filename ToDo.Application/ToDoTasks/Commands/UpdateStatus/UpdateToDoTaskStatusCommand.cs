using MediatR;

namespace ToDo.Application.ToDoTasks.Commands.UpdateStatus
{
    public record UpdateToDoTaskStatusCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public TaskStatus Status { get; set; }
    }
}
