using AutoMapper;
using MediatR;
using ToDo.Domain.Entities;
using ToDo.Persistence;

namespace ToDo.Application.ToDoTasks.Commands.Create
{
    public class CreateToDoTaskCommandHandler : IRequestHandler<CreateToDoTaskCommand, ToDoTask>
    {
        private readonly ApplicationContextDb _context;
        private readonly IMapper _mapper;
        public CreateToDoTaskCommandHandler(ApplicationContextDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ToDoTask> Handle(CreateToDoTaskCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
                return null;

            var todoTask = _mapper.Map<ToDoTask>(request.ToDo);
            todoTask.UserId = request.UserId;

            await _context.ToDoTasks.AddAsync(todoTask, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return todoTask;
        }
    }
}
