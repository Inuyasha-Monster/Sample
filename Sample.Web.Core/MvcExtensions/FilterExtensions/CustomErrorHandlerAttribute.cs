using Sample.Core.Infrastructure;
using Sample.Core.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sample.Web.Core.MvcExtensions.FilterExtensions
{
    public class CustomErrorHandlerAttribute : System.Web.Mvc.HandleErrorAttribute
    {
        private readonly ILogger _log;

        public CustomErrorHandlerAttribute()
        {
            this._log = ServiceContainer.Resole<ILogger>();
        }

        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException(nameof(filterContext));
            }
            if (filterContext.Exception != null)
            {
                string controllerName = filterContext.Controller.GetType().Name;
                string actionName =
                filterContext.RouteData.Values["action"] as string;
                this._log.Error($@"当前控制器:{controllerName},当前操作方法:{actionName ?? string.Empty}", filterContext.Exception);
            }
            base.OnException(filterContext);
        }
    }
}
