using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ToDo.Application.Common.Interfaces;
using ToDo.Domain.Entities;

namespace ToDo.Application.ToDoTasks.Commands.Create
{
    public class CreateToDoTaskCommandHandler : IRequestHandler<CreateToDoTaskCommand, ToDoTask>
    {
        private readonly IApplicationContextDb _context;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        public CreateToDoTaskCommandHandler(IApplicationContextDb context, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<ToDoTask> Handle(CreateToDoTaskCommand request, CancellationToken cancellationToken)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == request.UserId);

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
