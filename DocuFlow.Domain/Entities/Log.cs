using System;
using System.ComponentModel.DataAnnotations;

namespace DocuFlow.Domain.
Entities
{
    public class Log
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string Action { get; set; } = string.Empty;
        public string PerformedBy { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid? DocumentId { get; set; }
    }
}