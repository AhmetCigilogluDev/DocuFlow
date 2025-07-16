namespace DocuFlow.Domain.Entities
{
    public class Folder
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid? ParentFolderId { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        
    }
}