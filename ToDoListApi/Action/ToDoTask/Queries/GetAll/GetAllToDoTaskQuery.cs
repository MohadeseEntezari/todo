using MediatR;
using ToDoListApi.Dto;

namespace ToDoListApi.Action.ToDoTask.Queries.GetAll
{
    public record GetAllToDoTaskQuery(Guid? UserId) : IRequest<IEnumerable<ToDoTaskDto>>
    {
    }
}
