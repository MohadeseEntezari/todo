using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDo.Application.ToDoTasks.Commands.Create;
using ToDo.Application.ToDoTasks.Commands.Delete;
using ToDo.Application.ToDoTasks.Commands.Update;
using ToDo.Application.ToDoTasks.Commands.UpdateStatus;
using ToDo.Application.ToDoTasks.Queries.GetAll;
using ToDo.Application.ToDoTasks.Queries.GetById;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TodoTasksController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly Guid UserId;
        public TodoTasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateToDoTaskCommand command)
        {
            command.UserId = Guid.Parse(Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);

            var task = await _mediator.Send(command);
            return Ok(task);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var task = await _mediator.Send(new GetToDoTaskByIdQuery(id));
            return Ok(task);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateToDoTaskCommand command)
        {
            command.UserId = Guid.Parse(Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);
            ;
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteToDoTaskCommand command)
        {
            command.UserId = Guid.Parse(Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(Guid? userId)
        {
            var tasks = await _mediator.Send(new GetAllToDoTaskQuery(userId));
            return Ok(tasks);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateStatus(UpdateToDoTaskStatusCommand command)
        {
            command.UserId = Guid.Parse(Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
