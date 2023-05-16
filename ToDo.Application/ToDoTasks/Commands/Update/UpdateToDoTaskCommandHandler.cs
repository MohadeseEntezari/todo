using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Persistence;

namespace ToDo.Application.ToDoTasks.Commands.Update
{
    public class UpdateToDoTaskCommandHandler : IRequestHandler<UpdateToDoTaskCommand>
    {
        private readonly ApplicationContextDb _context;
        public UpdateToDoTaskCommandHandler(ApplicationContextDb context)
        {
            _context = context;
        }
        public async Task Handle(UpdateToDoTaskCommand request, CancellationToken cancellationToken)
        {
            var toDoTask = await _context.ToDoTasks.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId, cancellationToken);
            if (toDoTask == null)
                throw new KeyNotFoundException();

            toDoTask.Update(request.Title, DateTime.Parse(request.ToDoDate));

            _context.ToDoTasks.Update(toDoTask);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
