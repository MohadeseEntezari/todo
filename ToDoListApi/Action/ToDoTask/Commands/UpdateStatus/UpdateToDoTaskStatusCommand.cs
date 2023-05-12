using MediatR;

namespace ToDoListApi.Action.ToDoTask.Commands.UpdateStatus
{
    public record UpdateToDoTaskStatusCommand:IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public TaskStatus Status { get; set; }
    }
}
