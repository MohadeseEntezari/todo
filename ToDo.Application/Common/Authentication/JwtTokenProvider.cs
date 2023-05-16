using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDo.Persistence;

namespace ToDo.Application.Common.Authentication
{
    public class JwtTokenProvider : IJwtTokenProvider
    {
        private readonly ApplicationContextDb _context;
        private readonly JwtConfig _jwtConfig;

        public JwtTokenProvider(ApplicationContextDb context, IOptions<JwtConfig> jwtConfig)
        {
            _jwtConfig = jwtConfig.Value;
            _context = context;
        }
        public async Task<string> GenerateJwtToken(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_jwtConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Sid, userId.ToString()),
                    new Claim(ClaimTypes.Name, $"{user.Firstname} {user.Lastname}")
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
