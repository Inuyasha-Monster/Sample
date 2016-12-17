using Sample.Web.Core.MvcExtensions.FilterExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Web.App.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(System.Web.Mvc.GlobalFilterCollection filters)
        {
            filters.Add(new CustomErrorHandlerAttribute());
        }
    }
}