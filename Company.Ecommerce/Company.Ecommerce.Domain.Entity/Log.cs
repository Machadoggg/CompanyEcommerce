using System;

namespace Company.Ecommerce.Domain.Entity
{
    public class Log
    {
        public int LogId { get; set; }
        public string LogLevel { get; set; } = default!;
        public string Message { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
