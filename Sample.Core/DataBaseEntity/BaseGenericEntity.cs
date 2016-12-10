using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.DataBaseEntity
{
    /// <summary>
    /// 基础泛型实体类
    /// </summary>
    /// <typeparam name="T">主键约束为值类型：Int Guid</typeparam>
    public class BaseGenericEntity<T> where T : struct
    {
        public T ID { get; set; }
    }
}
