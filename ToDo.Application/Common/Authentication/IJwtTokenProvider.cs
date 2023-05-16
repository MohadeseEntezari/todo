namespace ToDo.Application.Common.Authentication
{
    public interface IJwtTokenProvider
    {
        Task<string> GenerateJwtToken(Guid userId);

    }
}
