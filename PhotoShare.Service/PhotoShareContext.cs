using System.Data.Entity;

namespace PhotoShare.Service
{
    public class PhotoShareContext : DbContext
    {
        public PhotoShareContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<AuthorizedUser> AuthorizedUsers { get; set; } 
        public DbSet<Photo> Photos { get; set; }
    }
}
