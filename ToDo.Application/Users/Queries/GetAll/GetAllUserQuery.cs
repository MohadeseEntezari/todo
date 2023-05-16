using MediatR;
using ToDo.Application.Common.Models;

namespace ToDo.Application.Users.Queries.GetAll
{
    public record GetAllUserQuery : IRequest<IEnumerable<UserDto>>;
}
