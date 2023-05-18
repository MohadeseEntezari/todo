namespace ToDo.Application.Common.Authentication
{
    public interface IJwtTokenProvider
    {
        string GenerateJwtToken(string userId);

    }
}
