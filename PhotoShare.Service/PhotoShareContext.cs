using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using PhotoShare.Domain;

namespace PhotoShare.Service
{
    public class PhotoShareContext : DbContext
    {
        public PhotoShareContext()
            : base("DefaultConnection")
        {}
        
        public DbSet<User> Users { get; set; } 
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Photo>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Comment>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
