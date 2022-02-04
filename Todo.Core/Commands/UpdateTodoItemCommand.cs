using MediatR;
using Todo.Common.Dto;
using Todo.Core.Models;

namespace Todo.Core.Commands
{
    public class UpdateTodoItemCommand : IRequest<RequestResult<TodoItemDto>>
    {
        public long Id { get; set; }

        public string TaskName { get; set; }

        public bool IsCompleted { get; set; }

        public string Commentary { get; set; }
    }
}
