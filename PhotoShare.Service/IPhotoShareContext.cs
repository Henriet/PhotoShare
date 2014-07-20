using System.Data.Entity;

namespace PhotoShare.Service
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        void Dispose();
    } 
}
