using System.Security.Cryptography;

namespace Todo.Core.Models
{
    public class RequestResult<T>
    {
        public bool Error { get; set; }
        public string ErrorMessage { get; set; }

        public T Result { get; set; }
    }
}
