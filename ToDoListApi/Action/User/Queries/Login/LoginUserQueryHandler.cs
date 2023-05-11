using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Action.User.Vm;
using ToDoListApi.Data;
using ToDoListApi.Infrastructure.Authentication;

namespace ToDoListApi.Action.User.Queries.Login
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, UserLoginVm>
    {
        private readonly ApplicationContextDb _context;
        private readonly IPasswordHasher<Domain.User> _passwordHasher;
        private readonly IJwtTokenProvider _jwtTokenProvider;
        public LoginUserQueryHandler(ApplicationContextDb context, IPasswordHasher<Domain.User> passwordHasher, IJwtTokenProvider jwtTokenProvider)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _jwtTokenProvider = jwtTokenProvider;
        }

        public async Task<UserLoginVm> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Mobile == request.Mobile);
            if (user is null)
                throw new Exception("User not found!");

            var verifyPassword = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);

            if (verifyPassword != PasswordVerificationResult.Success)
                throw new Exception("Password is incorrect!");

            var token = await _jwtTokenProvider.GenerateJwtToken(user.Id);

            return new UserLoginVm
            {
                Token = token
            };
        }
    }
}
