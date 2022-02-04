using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Todo.Core.Commands;
using Todo.Core.Queries;
using Todo.Domain.UnitOfWork;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("todo")]
        public async Task<object> GetTodoItem([FromQuery] long id) => await _mediator.Send(new TodoItemQuery(id));

        [HttpPost("todo")]
        public async Task<object> AddTodoItem([FromBody] CreateTodoItemCommand todoItemCommand) =>
            await _mediator.Send(todoItemCommand, CancellationToken.None);

        [HttpPut("todo")]
        public async Task<object> UpdateTodoItem(UpdateTodoItemCommand updateTodoItemCommand) =>
            await _mediator.Send(updateTodoItemCommand);
    }
}
