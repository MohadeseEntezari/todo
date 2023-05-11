using AutoMapper;
using MediatR;
using ToDoListApi.Data;
using ToDoListApi.Dto;

namespace ToDoListApi.Action.ToDoTask.Commands.Create
{
    public class CreateToDoTaskCommandHandler : IRequestHandler<CreateToDoTaskCommand, ToDoTaskDto>
    {
        private readonly ApplicationContextDb _context;
        private readonly IMapper _mapper;
        public CreateToDoTaskCommandHandler(ApplicationContextDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ToDoTaskDto> Handle(CreateToDoTaskCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
                return null;

            var todoTask = _mapper.Map<Domain.ToDoTask>(request);
            todoTask.User = user;

            await _context.ToDoTasks.AddAsync(todoTask, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            
            return _mapper.Map<ToDoTaskDto>(todoTask);
        }
    }
}
