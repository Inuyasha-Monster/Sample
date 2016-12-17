using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Sample.Core.Infrastructure;
using Sample.Web.Core.AssemblyExtensions;
using System.Configuration;
using Sample.Core.Config;
using Sample.Repository.EntityFramework.DbContexts;
using Sample.Core.Cache;
using Sample.Core.Log;
using Sample.Core.IBaseRepository;
using Sample.Repository.Repository;
using Sample.Core.UnitOfWork;
using Sample.Service.Account;

namespace Sample.Web.App.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = ServiceContainer.CurrentContainer;
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>(new PerRequestLifetimeManager());

            #region 注册基础服务

            container.RegisterType<ICacheManager, RuntimeCacheManager>();

            var applicationConfiguration = ConfigurationManager.GetSection("applicationConfig") as ApplicationSection;

            container.RegisterInstance<ApplicationSection>(applicationConfiguration);

            container.RegisterType<ILogger, CustomLogger>();

            container.RegisterInstance<ITypeFinder>(typeof(AppDomainTypeFinder).Name, new AppDomainTypeFinder());

            container.RegisterInstance<ITypeFinder>(typeof(WebAppTypeFinder).Name, new WebAppTypeFinder());


            #endregion

            #region 注册仓储和工作单元

            container.RegisterType(typeof(IGenericRepository<>), typeof(EfGenericRepository<>));

            container.RegisterType<IAccountRepository, AccountRepository>();

            container.RegisterType<IUnitOfWork, UnitOfWork>();

            container.RegisterType<IDbContext, SampleDbContext>(new PerRequestLifetimeManager());

            #endregion


            #region 注册应用服务

            container.RegisterType<IAccountService, AccountService>();

            #endregion



        }
    }
}
