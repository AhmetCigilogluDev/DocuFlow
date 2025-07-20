namespace DocuFlow.Application.DTO
{
    public class FolderDto
    {
        //Id(Guid), Name(string), ParentFolderId(Guid?), CreatedAt(DateTİme)

        public Guid Id { get; set; }
       public string Name { get; set; }
        public Guid? ParentFolderId { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}