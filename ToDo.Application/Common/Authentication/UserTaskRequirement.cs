using Microsoft.AspNetCore.Authorization;

namespace ToDo.Application.Common.Authentication
{
    public class UserTaskRequirement : IAuthorizationRequirement
    {
        public UserTaskRequirement()
        {
        }
    }
}
