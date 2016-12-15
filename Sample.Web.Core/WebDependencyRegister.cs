using Sample.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Sample.Web.Core.AssemblyExtensions;

namespace Sample.Web.Core
{
    public class WebDependencyRegister : IDependencyRegister
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterInstance<ITypeFinder>(typeof(WebAppTypeFinder).Name, new WebAppTypeFinder());
        }
    }
}
