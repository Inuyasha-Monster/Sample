using Sample.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Sample.Core.IBaseRepository;
using Sample.Repository.Repository;
using Sample.Core.UnitOfWork;
using Sample.Repository.EntityFramework.DbContexts;
using Sample.Service.Account;

namespace Sample.Service
{
    public class ServiceDependencyRegister : IDependencyRegister
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType(typeof(IGenericRepository<>), typeof(EfGenericRepository<>));

            container.RegisterType<IAccountRepository, AccountRepository>();

            container.RegisterType<IUnitOfWork, UnitOfWork>();

            container.RegisterType<IDbContext, SampleDbContext>();

            container.RegisterType<IAccountService, AccountService>();
        }
    }
}
