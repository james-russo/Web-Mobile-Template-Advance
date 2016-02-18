using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Configuration;
using DemoMobile;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(MobileRepository))]
namespace DemoMobile
{
    public class MobileRepository : IRepository
    {
        public IEnumerable<T> GetAll<T>() where T : class, new()
        {
            var conn = DependencyService.Get<ISqlLite>().GetConnection();

            conn.CreateTable<T>();

            return conn.Table<T>();
        }

        public IEnumerable<T> GetAll<T>(Func<T, bool> expression) where T : class, new()
        {
            var conn = DependencyService.Get<ISqlLite>().GetConnection();
            conn.CreateTable<T>();
            return conn.Table<T>().Where(expression);
        }

        public void InsertOrUpdate<T>(T source) where T : class, new()
        {
            var conn = DependencyService.Get<ISqlLite>().GetConnection();

            conn.CreateTable<T>();

            conn.Insert(source);
        }

        public void Delete<T>(T item) where T : class, IRemovable, new()
        {
            var conn = DependencyService.Get<ISqlLite>().GetConnection();

            item.IsActive = false;

            conn.Update(item);
        }

        public void Purge<T>(T item) where T : class, new()
        {
            var conn = DependencyService.Get<ISqlLite>().GetConnection();

            conn.Delete(item);
        }
    }
}
