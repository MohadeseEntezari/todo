using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ToDo.Application.Common.Interfaces;

namespace ToDo.Application.Common.Authentication
{
    public class UserTaskAuthorizationHandler : AuthorizationHandler<UserTaskRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IApplicationContextDb _context;
        public UserTaskAuthorizationHandler(IApplicationContextDb context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UserTaskRequirement requirement)
        {

            var taskId = _httpContextAccessor.HttpContext.GetRouteData()?.Values["id"]?.ToString();
            if (taskId is not null)
            {
                var userId = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;

                var task = await _context.ToDoTasks.FirstOrDefaultAsync(x => x.Id == Guid.Parse(taskId.ToString()) && x.UserId == userId);
                if (task != null)
                {
                    context.Succeed(requirement);

                }

            }
            else
            {
                context.Succeed(requirement);

            }


        }
    }
}
