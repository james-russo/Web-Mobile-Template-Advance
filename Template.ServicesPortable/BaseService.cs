using System;
using System.Collections.Generic;
using Demo.Configuration;
using System.Reflection.Emit;

namespace Demo.ServicesPortable
{
    public class BaseService<T> where T : class, new()
    {
        private IRepository Repository;

        public BaseService(IRepository repo)
        {
            Repository = repo;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Repository.GetAll<T>();
        }

        public virtual IEnumerable<T> GetAll(Func<T, bool> expression)
        {
            return Repository.GetAll<T>(expression);
        }

        protected void InsertOrUpdate<T>(T source) where T : class, new()
        {
            Repository.InsertOrUpdate(source);
        }

        protected void Purge(T source)
        {
            Repository.Purge(source);
        }
    }
}
