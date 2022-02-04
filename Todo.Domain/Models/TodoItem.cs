namespace Todo.Domain.Models
{
    public class TodoItem : BaseModel
    {
        public string TaskName { get; set; }

        public bool IsCompleted { get; set; }

        public string Commentary { get; set; }
    }
}
