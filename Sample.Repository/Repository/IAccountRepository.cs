using Sample.Core.IBaseRepository;
using Sample.Repository.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Repository.Repository
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Account GetByName(string name);
    }
}
