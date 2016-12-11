using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.Config
{
    public class ApplicationSection : ConfigurationSection
    {
        private const string RedisCacheConfigListPropertyName = "redisConfigList";
        private const string PageConfigPropertyName = "pageConfig";
        private const string MongoDbConfigPropertyName = "mongoDbConfig";

        [ConfigurationProperty(RedisCacheConfigListPropertyName, IsRequired = true, IsDefaultCollection = true)]
        public RedisCacheElementCollection RedisCacheConfigList
        {
            get
            {
                return ((RedisCacheElementCollection)(base[RedisCacheConfigListPropertyName]));
            }
        }


        [ConfigurationProperty(PageConfigPropertyName, IsRequired = true, IsDefaultCollection = false)]
        public PageSizeConfig PageConfig
        {
            get
            {
                return (PageSizeConfig)base[PageConfigPropertyName];
            }
        }


        [ConfigurationProperty(MongoDbConfigPropertyName, IsRequired = true, IsDefaultCollection = false)]
        public MongoDbConfig MongoDbConfig
        {
            get
            {
                return (MongoDbConfig)base[MongoDbConfigPropertyName];
            }
        }
    }
}
