using System;
using System.ComponentModel.DataAnnotations;

namespace Todo.Domain.Models
{
    public class BaseModel
    {
        [Key]
        public long Id { get; set; }

        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
