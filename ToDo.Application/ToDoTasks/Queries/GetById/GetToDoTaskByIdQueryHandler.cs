using MediatR;
using ToDo.Application.Common.Interfaces;
using ToDo.Domain.Entities;

namespace ToDo.Application.ToDoTasks.Queries.GetById
{
    public class GetToDoTaskByIdQueryHandler : IRequestHandler<GetToDoTaskByIdQuery, ToDoTask>
    {
        private readonly IApplicationContextDb _context;
        public GetToDoTaskByIdQueryHandler(IApplicationContextDb context)
        {
            _context = context;
        }
        public async Task<ToDoTask> Handle(GetToDoTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _context.ToDoTasks.FindAsync(request.Id);

            return task;
        }
    }
}
