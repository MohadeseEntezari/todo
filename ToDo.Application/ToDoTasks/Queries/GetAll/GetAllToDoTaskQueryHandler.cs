using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Persistence;

namespace ToDo.Application.ToDoTasks.Queries.GetAll
{
    public class GetAllToDoTaskQueryHandler : IRequestHandler<GetAllToDoTaskQuery, IEnumerable<ToDoTask>>
    {
        private readonly ApplicationContextDb _context;
        public GetAllToDoTaskQueryHandler(ApplicationContextDb context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ToDoTask>> Handle(GetAllToDoTaskQuery request, CancellationToken cancellationToken)
        {
            if (request.UserId is null)
                return await _context.ToDoTasks.ToListAsync(cancellationToken: cancellationToken);

            return _context.ToDoTasks.Where(x => x.UserId == request.UserId);
        }
    }
}
