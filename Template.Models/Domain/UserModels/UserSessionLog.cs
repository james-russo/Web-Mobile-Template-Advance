using System;
using Demo.Configuration;

namespace Demo.Models.Domain.UserModels
{
    public class UserSessionLog : IObject
    {
        public virtual int Id { get; set; }
        public virtual int UserProfileId { get; set; }
        public virtual string IPAddress { get; set; }
        public virtual string UserAgent { get; set; }
        public virtual DateTime SessionStart { get; set; }
        public virtual DateTime? SessionEnd { get; set; }

        public virtual UserProfile Profile { get; set; }
    }
}
