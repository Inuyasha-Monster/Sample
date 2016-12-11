using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.Config
{
    public class PageSizeConfig : ConfigurationElement
    {
        private const string MaxPageSizePropertyName = "maxPageSize";
        private const string MinPagePropertyName = "minPageSize";

        [ConfigurationProperty(MaxPageSizePropertyName, IsRequired = true, DefaultValue = "500")]
        public int MaxPageSize
        {
            get
            {
                return (int)base[MaxPageSizePropertyName];
            }
        }

        [ConfigurationProperty(MinPagePropertyName, IsRequired = true, DefaultValue = "10")]
        public int MinPageSize
        {
            get
            {
                return (int)base[MinPagePropertyName];
            }
        }
    }
}
