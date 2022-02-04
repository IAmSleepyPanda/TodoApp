using Todo.Common.Dto;
using Todo.Domain.Models;

namespace Todo.Common.Mappers
{
    public static class TodoItemMapper
    {
        public static TodoItemDto MapTodoItemDto(this TodoItem todoItem) =>
            new TodoItemDto
            {
                Id = todoItem.Id,
                TaskName = todoItem.TaskName,
                Commentary = todoItem.Commentary,
                IsCompleted = todoItem.IsCompleted,
                CreateDate = todoItem.CreateDateTime
            };
    }
}
