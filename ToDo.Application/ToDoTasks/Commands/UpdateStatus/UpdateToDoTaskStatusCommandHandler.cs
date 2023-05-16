using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Persistence;

namespace ToDo.Application.ToDoTasks.Commands.UpdateStatus
{
    public class UpdateToDoTaskStatusCommandHandler : IRequestHandler<UpdateToDoTaskStatusCommand>
    {
        private readonly ApplicationContextDb _context;
        public UpdateToDoTaskStatusCommandHandler(ApplicationContextDb context)
        {
            _context = context;
        }
        public async Task Handle(UpdateToDoTaskStatusCommand request, CancellationToken cancellationToken)
        {
            var task = await _context.ToDoTasks.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (task is null)
                throw new KeyNotFoundException();

            task.UpdateStatus(request.Status);
            _context.ToDoTasks.Update(task);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
