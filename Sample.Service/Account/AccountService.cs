using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Repository.EntityFramework.Models;
using Sample.Core.UnitOfWork;
using Sample.Repository.Repository;

namespace Sample.Service.Account
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRepository _repository;

        public AccountService(IUnitOfWork unitOfWork, IAccountRepository repository)
        {
            this._unitOfWork = unitOfWork;
            this._repository = repository;
        }

        public Repository.EntityFramework.Models.Account GetByName(string name)
        {
            return this._repository.GetByName(name);
        }

        public bool Add(Repository.EntityFramework.Models.Account item)
        {
            var b = this._unitOfWork.RegisteNew(item);
            this._unitOfWork.Commit();
            return b;
        }
    }
}
