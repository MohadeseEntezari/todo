using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Users.Commands.Create;
using ToDo.Application.Users.Queries.GetAll;
using ToDo.Application.Users.Queries.Login;
using ToDo.Application.Common.Models;
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

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserQuery query)
        {
            var token = await _mediator.Send(query);
            return Ok(token);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _mediator.Send(new GetAllUserQuery());
            return Ok(users);
        }
    }
}
