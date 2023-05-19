using FluentValidation;

namespace ToDo.Application.Users.Queries.Login
{
    public class LoginUserQueryValidation : AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidation()
        {
            RuleFor(x => x.Mobile).Matches(@"^(0)+9\d{9}$").NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
