using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Users.Commands.Create;
using ToDo.Application.Users.Queries.Login;
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
             await _mediator.Send(request);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserQuery query)
        {
            var token = await _mediator.Send(query);
            return Ok(token);
        }
    }
}
