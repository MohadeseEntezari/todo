using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Action.User.Commands.Create;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand request)
        {
            var user = await _mediator.Send(request);
            return Ok(user);
        }
    }
}
