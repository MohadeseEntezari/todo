namespace ToDoListApi.Infrastructure.Authentication
{
    public interface IJwtTokenProvider
    {
        Task<string> GenerateJwtToken(Guid userId);

    }
}
