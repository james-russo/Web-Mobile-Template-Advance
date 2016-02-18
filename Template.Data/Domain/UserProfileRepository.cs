
using DemoData.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Models.Domain.UserModels;
using NHibernate;
using NHibernate.Linq;

namespace Demo.Data.Domain
{
    public class UserProfileRepository
    {
        public List<UserProfile> GetUserProfiles()
        {
            using (NHibernateSession factory = new NHibernateSession())
            {
                using (ISession session = factory.OpenSession())
                {
                    var employees = session.Query<UserProfile>().ToList();

                    return employees;
                }
            }
        }
    }
}
