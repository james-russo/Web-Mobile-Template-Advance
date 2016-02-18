using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Configuration
{
    public interface IRemovable
    {
        bool IsActive { get; set; }
    }
}
