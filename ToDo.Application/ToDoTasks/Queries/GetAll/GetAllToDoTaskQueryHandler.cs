using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Common.Interfaces;
using ToDo.Domain.Entities;

namespace ToDo.Application.ToDoTasks.Queries.GetAll
{
    public class GetAllToDoTaskQueryHandler : IRequestHandler<GetAllToDoTaskQuery, IEnumerable<ToDoTask>>
    {
        private readonly IApplicationContextDb _context;
        public GetAllToDoTaskQueryHandler(IApplicationContextDb context)
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
