using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Sample.Core.Cache;
using Sample.Core.Config;
using Sample.Core.Log;

namespace Sample.Core.Infrastructure
{
    public class BasicDependencyRegister : IDependencyRegister
    {
        public void RegisterTypes(IUnityContainer container)
        {
            #region CacheRegister

            container.RegisterType<ICacheManager, NullCacheManager>(new TransientLifetimeManager());

            #endregion

            #region TypeFinderRegister


            container.RegisterType<ITypeFinder, AppDomainTypeFinder>(new ContainerControlledLifetimeManager());


            #endregion

            #region LogRegister

            container.RegisterType<ILogger, NullLogger>(new TransientLifetimeManager());

            #endregion
        }
    }
}
