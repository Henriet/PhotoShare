using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PhotoShare.Service.Repository
{
    public class Repository<T> where T : class
    {
        private readonly DbContext _context = new PhotoShareContext();
        private bool _disposed;

        private IDbSet<T> _objectset;

        private IDbSet<T> DbSet
        {
            get { return _objectset ?? (_objectset = _context.Set<T>()); }
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public T Get(Guid id)
        {
            return DbSet.Find(id);
        }

        public T Insert(T item)
        {
            T entity = DbSet.Add(item);
            CommitChanges();
            return entity;
        }

        public bool Update(T entity)
        {
            DbSet.Attach(entity);

            _context.Entry(entity).State = EntityState.Modified;
            CommitChanges();
            return true;
        }

        public bool Delete(Guid id)
        {
            T entity = Get(id);
            if (entity == null) return false;

            DbSet.Remove(entity);
            CommitChanges();
            return true;
        }

        public void CommitChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw  new Exception(ex.Message, ex);
            }
        }

        public List<T> All()
        {
            return  DbSet.ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).AsEnumerable();
        }
         
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
