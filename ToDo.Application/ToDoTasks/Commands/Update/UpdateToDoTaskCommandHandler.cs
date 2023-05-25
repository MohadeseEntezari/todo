using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Common.Interfaces;

namespace ToDo.Application.ToDoTasks.Commands.Update
{
    public class UpdateToDoTaskCommandHandler : IRequestHandler<UpdateToDoTaskCommand>
    {
        private readonly IApplicationContextDb _context;
        public UpdateToDoTaskCommandHandler(IApplicationContextDb context)
        {
            _context = context;
        }
        public async Task Handle(UpdateToDoTaskCommand request, CancellationToken cancellationToken)
        {
            var toDoTask = await _context.ToDoTasks.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId, cancellationToken);
            if (toDoTask == null)
                throw new KeyNotFoundException();

            toDoTask.Update(request.ToDo.Title, DateTime.Parse(request.ToDo.TaskDate));

            _context.ToDoTasks.Update(toDoTask);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
