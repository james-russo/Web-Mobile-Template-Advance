using System;
using System.Collections.Generic;
using Demo.Configuration;

namespace Demo.Models.Domain.UserModels
{
    public partial class UserProfile : IObject
    {
        public virtual int Id { get; set; }
        public virtual Guid UserId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime? LastLoginDate { get; set; }

        //public virtual IList<UserSessionLog> SessionLogs { get; set; }
    }
}
