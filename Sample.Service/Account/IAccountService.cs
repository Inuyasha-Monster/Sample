using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Repository.EntityFramework;

namespace Sample.Service.Account
{
    public interface IAccountService
    {
        Repository.EntityFramework.Models.Account GetByName(string name);
    }
}
