using MediatR;
using Todo.Common.Dto;
using Todo.Core.Models;

namespace Todo.Core.Queries
{
    public class TodoItemQuery : IRequest<RequestResult<TodoItemDto>>
    {
        public TodoItemQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
