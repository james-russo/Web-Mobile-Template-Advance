using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Configuration;
using DemoData.Domain;
using NHibernate;
using NHibernate.Linq;

namespace Demo.Data
{
    public class NHibernateRespository : IRepository
    {
        protected readonly string ConnectionNameSpace = "NHibernate.Data.Domain.hibernate.cfg.xml";
        protected readonly string DataAssemblyName = "NHibernate.Data";

        public IEnumerable<T> GetAll<T>() where T : class, new()
        {
            using (NHibernateSession factory = new NHibernateSession())
            {
                using (ISession session = factory.OpenSession(ConnectionNameSpace, DataAssemblyName))
                {
                    var dataRows = session.Query<T>();

                    return dataRows.ToList();
                }
            }
        }

        public IEnumerable<T> GetAll<T>(Func<T, bool> expression) where T : class, new()
        {
            using (NHibernateSession factory = new NHibernateSession())
            {
                using (ISession session = factory.OpenSession(ConnectionNameSpace, DataAssemblyName))
                {
                    var dataRows = session.Query<T>().Where(expression);

                    return dataRows.ToList();
                }
            }
        }

        public void InsertOrUpdate<T>(T source) where T : class, new()
        {
            using (NHibernateSession factory = new NHibernateSession())
            {
                using (ISession session = factory.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(source);
                        transaction.Commit();
                    }
                }
            }
        }

        public void Delete<T>(T item) where T : class, IRemovable, new()
        {
            throw new NotImplementedException();
        }

        public void Purge<T>(T item) where T : class, new()
        {
            throw new NotImplementedException();
        }
    }
}
