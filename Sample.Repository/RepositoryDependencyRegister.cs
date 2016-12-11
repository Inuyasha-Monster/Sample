using Sample.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Sample.Core.IBaseRepository;
using Sample.Repository.Repository;

namespace Sample.Repository
{
    public class RepositoryDependencyRegister : IDependencyRegister
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType(typeof(IGenericRepository<>), typeof(EfGenericRepository<>));
        }
    }
}
