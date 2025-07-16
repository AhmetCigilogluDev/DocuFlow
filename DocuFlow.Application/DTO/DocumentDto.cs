namespace DocuFlow.Application.DTO
{

    public class DocumentDto

    {
        //Guid Id, Title, FileType, UploadType, CreatedAt, IsApproved, Tags
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public string UploadedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsApproved { get; set; }
        public List<string> Tags { get; set; } = new();
    }
}