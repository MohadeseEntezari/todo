using FluentValidation;

namespace ToDo.Application.ToDoTasks.Commands.Create
{
    public class CreateToDoTaskCommandValidation:AbstractValidator<CreateToDoTaskCommand>
    {
        public CreateToDoTaskCommandValidation()
        {
            RuleFor(x => x.ToDo.Title).NotEmpty();
            RuleFor(x => x.ToDo.TaskDate).NotEmpty();
        }
    }
}
