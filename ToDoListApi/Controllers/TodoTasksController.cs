using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Action.ToDoTask.Commands.Create;
using ToDoListApi.Action.ToDoTask.Commands.Delete;
using ToDoListApi.Action.ToDoTask.Commands.Update;
using ToDoListApi.Action.ToDoTask.Queries.GetAll;
using ToDoListApi.Action.ToDoTask.Queries.GetById;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TodoTasksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TodoTasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateToDoTaskCommand command)
        {
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
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteToDoTaskCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(Guid? userId)
        {
            var tasks = await _mediator.Send(new GetAllToDoTaskQuery(userId));
            return Ok(tasks);
        }

    }
}
