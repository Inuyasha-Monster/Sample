using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.Config
{
    public class RedisCacheElement : ConfigurationElement
    {
        private const string ConnectionStringPropertyName = "connectionString";
        private const string PortPorpertyName = "port";
        private const string EnablePorpertyName = "enable";

        [ConfigurationProperty(ConnectionStringPropertyName, IsRequired = true, DefaultValue = "127.0.0.1", IsDefaultCollection = false)]
        public string ConnectionString
        {
            get { return (string)base[ConnectionStringPropertyName]; }
        }

        [ConfigurationProperty(PortPorpertyName, IsRequired = true, DefaultValue = "6379", IsDefaultCollection = false)]
        public string Port
        {
            get { return (string)base[PortPorpertyName]; }
        }

        [ConfigurationProperty(EnablePorpertyName, IsRequired = true, DefaultValue = "true", IsDefaultCollection = false)]
        public bool Enable
        {
            get
            {
                return (bool)base[EnablePorpertyName];
            }
        }
    }
}
