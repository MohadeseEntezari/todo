using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Data;
using ToDoListApi.Dto;

namespace ToDoListApi.Action.ToDoTask.Queries.GetAll
{
    public class GetAllToDoTaskQueryHandler : IRequestHandler<GetAllToDoTaskQuery, IEnumerable<ToDoTaskDto>>
    {
        private readonly ApplicationContextDb _context;
        private readonly IMapper _mapper;
        public GetAllToDoTaskQueryHandler(ApplicationContextDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ToDoTaskDto>> Handle(GetAllToDoTaskQuery request, CancellationToken cancellationToken)
        {
            if (request.UserId is null)
                return _mapper.Map<IEnumerable<ToDoTaskDto>>(await _context.ToDoTasks.Include("User").ToListAsync(cancellationToken: cancellationToken));
            
            return _mapper.Map<IEnumerable<ToDoTaskDto>>(_context.ToDoTasks.Include("User").Where(x => x.UserId == request.UserId));
        }
    }
}
