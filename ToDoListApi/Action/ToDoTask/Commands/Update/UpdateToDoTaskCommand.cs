using MediatR;

namespace ToDoListApi.Action.ToDoTask.Commands.Update
{
    public record UpdateToDoTaskCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string ToDoDate { get; set; }
    }
}
