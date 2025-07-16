using System;
using System.ComponentModel.DataAnnotations;

namespace DocuFlow.Domain.Entities
{
    public class Log
    {
        public Guid id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Action { get; set; } = string.Empty;
        public string PerformedBy { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid? DocumentId { get; set; }
    }
}