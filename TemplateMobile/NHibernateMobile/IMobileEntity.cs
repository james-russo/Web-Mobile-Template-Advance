using Demo.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMobile
{
    public interface IMobileEntity : IObject
    {
        int MobileEntityId { get; set; }
    }
}
