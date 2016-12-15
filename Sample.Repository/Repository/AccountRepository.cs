using Sample.Repository.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Repository.EntityFramework.DbContexts;

namespace Sample.Repository.Repository
{
    public class AccountRepository : EfGenericRepository<Account>, IAccountRepository
    {
        private readonly IDbContext _context;
        public AccountRepository(IDbContext context) : base(context)
        {
            this._context = context;
        }

        public Account GetByName(string name)
        {
            return this._context.Set<Account>().FirstOrDefault(x => x.Name == name);
        }
    }
}
