using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Data.Domain.UserModels;
using NHibernateData.Domain;

namespace NHibernate.Services.UserProfileService
{
    public class UserProfileService : BaseService<UserProfile>
    {
        public UserProfileService() : base() { }

        public IEnumerable<UserProfile> GetProfiles(Func<UserProfile, bool> where = null)
        {          
            return where == null ? GetAll() : GetAll(where);
        }

       

        public void SaveProfile(UserProfile profile)
        {
            InsertOrUpdate(profile);
        }
    }
}
