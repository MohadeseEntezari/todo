using MediatR;

namespace ToDoListApi.Action.ToDoTask.Commands.Delete
{
    public record DeleteToDoTaskCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
