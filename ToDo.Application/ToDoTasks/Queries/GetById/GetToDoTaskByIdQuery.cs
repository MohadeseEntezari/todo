using MediatR;
using ToDo.Application.Common.Models;
using ToDo.Domain.Entities;

namespace ToDo.Application.ToDoTasks.Queries.GetById
{
    public record GetToDoTaskByIdQuery(Guid Id) : IRequest<ToDoTask>;
}
