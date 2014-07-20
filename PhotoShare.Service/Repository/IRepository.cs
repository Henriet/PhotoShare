﻿using System.Linq;

namespace PhotoShare.Service.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        //todo search
    }
}
