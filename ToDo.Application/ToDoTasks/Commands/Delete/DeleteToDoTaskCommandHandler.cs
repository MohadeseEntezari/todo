using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Common.Interfaces;

namespace ToDo.Application.ToDoTasks.Commands.Delete
{
    public class DeleteToDoTaskCommandHandler : IRequestHandler<DeleteToDoTaskCommand>
    {
        private readonly IApplicationContextDb _context;
        public DeleteToDoTaskCommandHandler(IApplicationContextDb context)
        {
            _context = context;
        }
        public async Task Handle(DeleteToDoTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _context.ToDoTasks.FirstOrDefaultAsync(x => x.UserId == request.UserId && x.Id == request.Id);

            if (task == null)
                throw new Exception("Not Found!");

            _context.ToDoTasks.Remove(task);
            await _context.SaveChangesAsync(cancellationToken);

        }
    }
}
