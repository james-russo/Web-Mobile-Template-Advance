using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Demo;
using NHibernate;
using NHibernate.Cfg;

namespace DemoData.Domain
{
    public class NHibernateSession : IDisposable
    {
        public ISession OpenSession()
        {
            return OpenSession("NHibernate.Data.Domain.hibernate.cfg.xml", "NHibernate.Models");
        }

        public ISession OpenSession(string ConnectionNameSpace, string DataAssemblyName)
        {
            var configuration = new Configuration();
            configuration.Configure(this.GetType().Assembly, ConnectionNameSpace);
            configuration.AddAssembly(DataAssemblyName);

            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }

        public void Dispose()
        {
        }
    }
}
