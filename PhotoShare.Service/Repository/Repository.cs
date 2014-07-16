using System;
using System.Data.Entity;
using System.Linq;

namespace PhotoShare.Service.Repository
{
    public class Repository<T> where T : class
    {
        private PhotoShareContext _context = new PhotoShareContext();
        
        private IDbSet<T> Entities
        {
            get { return _context.Set<T>(); }
        }

        public Repository(PhotoShareContext context)
        {
            _context = context;

        }

        public IQueryable<T> GetAll()
        {
            return Entities.AsQueryable();
            
        }

        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(T entity)
        {
            Entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            
            Entities.Remove(entity);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || _context == null) return;
            _context.Dispose();
            _context = null;
        }
    }
}
