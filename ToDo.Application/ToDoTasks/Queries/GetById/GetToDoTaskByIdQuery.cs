using MediatR;
using ToDo.Application.Common.Models;

namespace ToDo.Application.ToDoTasks.Queries.GetById
{
    public record GetToDoTaskByIdQuery(Guid Id) : IRequest<ToDoTaskDto>;
}
