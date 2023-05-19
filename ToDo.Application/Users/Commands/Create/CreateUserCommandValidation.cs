using FluentValidation;

namespace ToDo.Application.Users.Commands.Create
{
    public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidation()
        {
            RuleFor(x => x.Mobile).Matches(@"^(0)+9\d{9}$").NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
