using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Configuration
{
    public interface IRepository
    {
        IEnumerable<T> GetAll<T>() where T : class, new();

        IEnumerable<T> GetAll<T>(Func<T, bool> expression) where T : class, new();

        void InsertOrUpdate<T>(T source) where T : class, new();

        void Delete<T>(T item) where T :  class, IRemovable, new();

        void Purge<T>(T item) where T : class, new();
    }
}
