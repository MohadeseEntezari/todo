using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Data;
using ToDoListApi.Dto;

namespace ToDoListApi.Action.ToDoTask.Queries.GetById
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
            var task = await _context.ToDoTasks.FindAsync(request.Id, cancellationToken);

            return  _mapper.Map<ToDoTaskDto>(task);
        }
    }
}
