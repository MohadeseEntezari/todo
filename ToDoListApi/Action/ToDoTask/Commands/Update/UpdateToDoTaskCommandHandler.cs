using MediatR;
using ToDoListApi.Data;

namespace ToDoListApi.Action.ToDoTask.Commands.Update
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
            var toDoTask = await _context.ToDoTasks.FindAsync(request.Id, cancellationToken);
            if (toDoTask == null)
                throw new DirectoryNotFoundException();

            toDoTask.Update(request.Title, DateTime.Parse(request.ToDoDate));
            
            _context.ToDoTasks.Update(toDoTask);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
