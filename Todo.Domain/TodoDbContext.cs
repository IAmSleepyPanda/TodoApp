using Microsoft.EntityFrameworkCore;
using Todo.Domain.Models;

namespace Todo.Domain
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
