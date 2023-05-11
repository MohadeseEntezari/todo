using MediatR;
using ToDoListApi.Dto;

namespace ToDoListApi.Action.ToDoTask.Commands.Create
{
    public record CreateToDoTaskCommand:IRequest<ToDoTaskDto>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string TaskDate { get; set; }
    }
}
