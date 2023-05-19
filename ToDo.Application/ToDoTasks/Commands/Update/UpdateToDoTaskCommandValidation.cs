using FluentValidation;

namespace ToDo.Application.ToDoTasks.Commands.Update
{
    public class UpdateToDoTaskCommandValidation:AbstractValidator<UpdateToDoTaskCommand>
    {
        public UpdateToDoTaskCommandValidation()
        {
            RuleFor(x => x.ToDo.Title).NotEmpty();
            RuleFor(x => x.ToDo.TaskDate).NotEmpty();
        }
    }
}
