using MediatR;
using Todo.Domain.Models;

namespace Todo.Commands
{
    public class CreateTodoItemCommand : IRequest<TodoItem>, IRequest<Unit>
    {
        public string TaskName { get; set; }

        public bool IsCompleted { get; set; }

        public string Commentary { get; set; }
    }
}
