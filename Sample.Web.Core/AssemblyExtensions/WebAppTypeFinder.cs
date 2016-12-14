using Sample.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Web.Core.AssemblyExtensions
{
    public class WebAppTypeFinder : AppDomainTypeFinder
    {
        private bool binFolderAssembliesLoaded = false;

        public virtual string GetBinDiectory()
        {
            if (System.Web.Hosting.HostingEnvironment.IsHosted)
            {
                return System.Web.HttpRuntime.BinDirectory;
            }
            var dectory = AppDomain.CurrentDomain.BaseDirectory;
            return dectory;
        }

        public override IList<Assembly> GetAssemblies()
        {
            if (!binFolderAssembliesLoaded)
            {
                binFolderAssembliesLoaded = true;
                LoadMatchingAssemblies(GetBinDiectory());
            }
            return base.GetAssemblies();
        }
    }
}
