using MediatR;
using ToDoListApi.Dto;

namespace ToDoListApi.Action.User.Queries.GetAll
{
    public record GetAllUserQuery : IRequest<IEnumerable<UserDto>>;
}
