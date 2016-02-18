using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Demo.Configuration
{
    public interface IService
    {
        void Save<T>(T model) where T : class, new();
    }
}
