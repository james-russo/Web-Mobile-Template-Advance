using System;
using System.Collections.Generic;
using Demo.Configuration;
using Demo.Models.Domain.UserModels;

namespace Demo.ServicesPortable.UserProfileService
{
    public class UserProfileService : BaseService<UserProfile>
    {
        public UserProfileService(IRepository repository) : base(repository) { }

        public IEnumerable<UserProfile> GetProfiles(Func<UserProfile, bool> where = null)
        {          
            return where == null ? GetAll() : GetAll(where);
        }

       

        public void SaveProfile(UserProfile profile)
        {
            InsertOrUpdate(profile);
        }

        public void Save<TModel>(TModel model) where TModel : class, new()
        {
            InsertOrUpdate<TModel>(model);
        }

        public void DeleteProfile(UserProfile userProfile)
        {
            Purge(userProfile);
        }
    }
}
