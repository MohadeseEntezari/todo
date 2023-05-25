using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDo.Application.Common.Models;
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
    [Authorize(Policy = "userTasks")]
    public class TodoTasksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TodoTasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ToDoTaskDto dto)
        {
            var userId = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            if (userId == null)
                return Unauthorized();

            var task = await _mediator.Send(new CreateToDoTaskCommand { UserId = userId, ToDo = dto });

            return Ok(task);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var task = await _mediator.Send(new GetToDoTaskByIdQuery(id));
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ToDoTaskDto dto)
        {
            var userId = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            if (userId == null)
                return Unauthorized();

            await _mediator.Send(new UpdateToDoTaskCommand { Id = id, ToDo = dto, UserId = userId });
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userId = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            if (userId == null)
                return Unauthorized();


            await _mediator.Send(new DeleteToDoTaskCommand { Id = id, UserId = userId });
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string userId)
        {
            var tasks = await _mediator.Send(new GetAllToDoTaskQuery(userId));
            return Ok(tasks);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateStatus(Guid id, TaskStatus status)
        {
            var userId = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            if (userId == null)
                return Unauthorized();


            await _mediator.Send(new UpdateToDoTaskStatusCommand { Id = id, Status = status, UserId = userId });
            return Ok();
        }
    }
}
