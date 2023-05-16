using MediatR;
using ToDo.Application.Common.Models;

namespace ToDo.Application.ToDoTasks.Queries.GetAll
{
    public record GetAllToDoTaskQuery(Guid? UserId) : IRequest<IEnumerable<ToDoTaskDto>>
    {
    }
}
