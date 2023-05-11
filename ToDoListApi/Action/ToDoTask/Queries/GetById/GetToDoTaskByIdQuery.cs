using MediatR;
using ToDoListApi.Dto;

namespace ToDoListApi.Action.ToDoTask.Queries.GetById
{
    public record GetToDoTaskByIdQuery(Guid Id) : IRequest<ToDoTaskDto>;
}
