using Sample.Core.DataBaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.IBaseRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {

    }
}
