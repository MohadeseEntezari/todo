using AutoMapper;
using MediatR;
using ToDo.Application.Common.Models;
using ToDo.Persistence;

namespace ToDo.Application.ToDoTasks.Queries.GetById
{
    public class GetToDoTaskByIdQueryHandler : IRequestHandler<GetToDoTaskByIdQuery, ToDoTaskDto>
    {
        private readonly ApplicationContextDb _context;
        private readonly IMapper _mapper;
        public GetToDoTaskByIdQueryHandler(ApplicationContextDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ToDoTaskDto> Handle(GetToDoTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _context.ToDoTasks.FindAsync(request.Id);

            return _mapper.Map<ToDoTaskDto>(task);
        }
    }
}
