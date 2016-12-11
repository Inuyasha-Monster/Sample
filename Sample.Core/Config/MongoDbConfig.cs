using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.Config
{
    public class MongoDbConfig : ConfigurationElement
    {
        private const string ConnnectionStringPropertyName = "connectionString";
        private const string DatabasePropertyName = "database";
        private const string CollectionPropertyName = "collection";

        /// <summary>
        /// MongoDb连接字符串
        /// </summary>
        [ConfigurationProperty(name: ConnnectionStringPropertyName, DefaultValue = "mongodb://127.0.0.1:27017", IsRequired = true, IsDefaultCollection = false)]
        public string ConnnectionString
        {
            get
            {
                return (string)base[ConnnectionStringPropertyName];
            }
        }

        /// <summary>
        /// 默认数据库
        /// </summary>
        [ConfigurationProperty(DatabasePropertyName, IsRequired = true, DefaultValue = "logs", IsDefaultCollection = false)]
        public string Database
        {
            get
            {
                return (string)base[DatabasePropertyName];
            }
        }

        /// <summary>
        /// 默认表
        /// </summary>
        [ConfigurationProperty(CollectionPropertyName, IsRequired = true, DefaultValue = "log", IsDefaultCollection = false)]
        public string Collection
        {
            get
            {
                return (string)base[CollectionPropertyName];
            }
        }
    }
}
