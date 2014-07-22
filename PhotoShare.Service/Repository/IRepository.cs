using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PhotoShare.Service.Repository
{
    public interface IRepository<T> where T : class
    {
        T Get(Guid id);
        T Insert(T item);
        bool Update(T item);
        bool Delete(Guid id);
        void CommitChanges();

        List<T> All();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
