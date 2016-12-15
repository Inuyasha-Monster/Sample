using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTranscope();

        bool RegisteNew<TEntity>(TEntity entity)
            where TEntity : class;

        bool RegisteManyNew<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class;

        bool RegisteDirty<TEntity>(TEntity entity)
           where TEntity : class;

        bool RegisteManyDirty<TEntity>(IEnumerable<TEntity> entities)
           where TEntity : class;


        bool RegisteClear<TEntity>(TEntity entity)
           where TEntity : class;

        bool RegisteDelete<TEntity>(TEntity entity)
           where TEntity : class;

        bool RegisteManyDelete<TEntity>(IEnumerable<TEntity> entities)
           where TEntity : class;

        bool Commit();

        void Rollback();
    }
}
