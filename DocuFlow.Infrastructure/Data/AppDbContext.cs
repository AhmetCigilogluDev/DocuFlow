using Microsoft.EntityFrameworkCore;
using DocuFlow.Domain.Entities;

namespace  DocuFlow.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }




                  // Folder DbSet<Folder>, Documents DbSet<Documents> 
        // User Dbset<User> , Logs Dbset<Log> 

        public DbSet<Folder> Folders { get; set; }
        public DbSet<Document> Documents { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Log> Logs { get; set; }


        

      



    }
}