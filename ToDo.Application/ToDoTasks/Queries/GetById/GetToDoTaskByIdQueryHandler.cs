using AutoMapper;
using MediatR;
using ToDo.Application.Common.Models;
using ToDo.Domain.Entities;
using ToDo.Persistence;

namespace ToDo.Application.ToDoTasks.Queries.GetById
{
    public class GetToDoTaskByIdQueryHandler : IRequestHandler<GetToDoTaskByIdQuery, ToDoTask>
    {
        private readonly ApplicationContextDb _context;
        public GetToDoTaskByIdQueryHandler(ApplicationContextDb context)
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
