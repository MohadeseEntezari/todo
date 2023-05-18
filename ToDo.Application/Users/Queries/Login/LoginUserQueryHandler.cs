using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Authentication;
using ToDo.Application.Common.Authentication;

namespace ToDo.Application.Users.Queries.Login
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly IJwtTokenProvider _jwtTokenProvider;
        private readonly UserManager<IdentityUser> _userManager;
        public LoginUserQueryHandler(IJwtTokenProvider jwtTokenProvider, SignInManager<IdentityUser> signinManager, UserManager<IdentityUser> userManager)
        {
            _jwtTokenProvider = jwtTokenProvider;
            _signinManager = signinManager;
            _userManager = userManager;
        }

        public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var signInResult = await _signinManager.PasswordSignInAsync(request.Mobile, request.Password, true, false);
            if (!signInResult.Succeeded)
                throw new AuthenticationException("Unauthorized!");
            var user = await _userManager.FindByNameAsync(request.Mobile);
            return _jwtTokenProvider.GenerateJwtToken(user.Id);
        }
    }
}
