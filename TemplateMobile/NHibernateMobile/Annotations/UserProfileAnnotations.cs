using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Demo.Models.Domain.UserModels;

namespace DemoMobile.Annotations
{
    public class UserProfileViewModel : BaseAnnotation<UserProfile>
    {
        public UserProfileViewModel() : base(new UserProfile())
        {
        }

        private int id;

        public int Id
        {
            get { return id; }
            set{SetField(ref id, value);}
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName;
            }
            set { SetField(ref firstName, value); }
        }


        /// <summary>
        /// Example on how a service would be created using AutoFac and saving would be to a SQLite DB (local)
        /// due to the registration of the MobileRepository as the IRepository
        /// </summary>
        public void Save()
        {
        //using (var scope = App.Container.BeginLifetimeScope())
        //{
        //    var service = App.Container.Resolve<UserProfileService>();

        //    var ups = service.GetProfiles();

        //    if (!ups.Any())
        //    {
        //        var up = new UserProfile()
        //        {
        //            FirstName = "First John",
        //            LastLoginDate = DateTime.UtcNow,
        //            LastName = "Last Name",
        //            MiddleName = string.Empty,
        //            UserId = Guid.NewGuid()
        //        };

        //        service.SaveProfile(up);
        //    }
        //}
        }
    }
}
