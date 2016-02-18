using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo;
using System.Threading.Tasks;
using Demo.Models.Domain;
using NHibernate;
using NHibernate.Linq;

namespace DemoData.Domain
{
    public class EmployeeRepository
    {
        public List<Employee> GetEmployees()
        {
            using (NHibernateSession factory = new NHibernateSession())
            {
                using (ISession session = factory.OpenSession())
                {
                    var employees = session.Query<Employee>().ToList();

                    return employees;
                }
            }            
        }

        public void SaveEmployee(Employee source)
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

        public void DeleteEmployee(int id)
        {
            using (NHibernateSession factory = new NHibernateSession())
            {
                using (ISession session = factory.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        var employee = session.Query<Employee>().FirstOrDefault(x => x.Id == id);

                        session.Delete(employee);
                        transaction.Commit();
                    }
                }
            }
        }
    }
}
