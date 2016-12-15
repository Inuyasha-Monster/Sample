using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using Sample.Repository.EntityFramework.DbContexts;
using Sample.Core.UnitOfWork;
using Sample.Repository.Repository;
using Sample.Core.IBaseRepository;
using Sample.Service.Account;

namespace Sample.Test
{
    [TestClass]
    public class UnitTest
    {
        private static Lazy<IUnityContainer> _container = new Lazy<IUnityContainer>(() =>
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IDbContext, SampleDbContext>(new ContainerControlledLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType(typeof(IGenericRepository<>), typeof(EfGenericRepository<>));
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IAccountService, AccountService>();
            return container;
        });

        [TestMethod]
        public void TestMethod()
        {
            var service = _container.Value.Resolve<IAccountService>();
            var b = service.Add(new Repository.EntityFramework.Models.Account() { Name = "fuck", Password = "123123", Phone = "bbbbbbbbb" });
            Assert.IsTrue(b);
        }
    }
}
