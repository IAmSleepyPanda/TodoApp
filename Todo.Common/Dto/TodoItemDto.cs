using System;

namespace Todo.Common.Dto
{
    public class TodoItemDto
    {
        public long Id { get; set; }

        public DateTime CreateDate { get; set; }

        public string TaskName { get; set; }

        public bool IsCompleted { get; set; }

        public string Commentary { get; set; }
    }
}
