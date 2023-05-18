using MediatR;
using ToDo.Application.Common.Models;
using ToDo.Domain.Entities;

namespace ToDo.Application.ToDoTasks.Queries.GetAll
{
    public record GetAllToDoTaskQuery(string UserId) : IRequest<IEnumerable<ToDoTask>>
    {
    }
}
