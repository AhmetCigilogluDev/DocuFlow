namespace DocuFlow.Domain.Entities
{
    public class Document{
        //Guid Id, Title, FilePath, FileType, UploadedBy,
        //CreatedAt, LastModifiedAt, IsApproved, List<> Tags, Guid? FolderId, VersionNumber
        public Guid Id {get; set;}
        
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string FilePath {get; set;} = string.Empty;
        public string FileType {get; set;} = string.Empty;
        public string UploadedBy {get; set;} = string.Empty;
         public DateTime CreatedAt {get; set;}
         public DateTime LastModifiedAt {get; set;}
         public bool IsApproved {get; set;}
         public List<string> Tags {get; set;} = new();
         public Guid? FolderId {get; set;}
         public int VersionNumber {get; set;} = 1;
        
        //
    }
}