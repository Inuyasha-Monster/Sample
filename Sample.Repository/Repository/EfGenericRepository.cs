using Sample.Core.DataBaseEntity;
using Sample.Core.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Repository.Repository
{
    public class EfGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {

    }
}
