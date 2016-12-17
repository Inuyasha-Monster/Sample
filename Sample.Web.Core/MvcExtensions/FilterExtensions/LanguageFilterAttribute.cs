using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sample.Web.Core.MvcExtensions.FilterExtensions
{
    public class LanguageFilterAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (filterContext == null)
            {
                throw new ArgumentNullException(nameof(filterContext));
            }
            var language = filterContext.RouteData.Values["language"].ToString();
            if (string.IsNullOrWhiteSpace(language))
            {
                language = "zh-cn";
            }
            else
            {
                string[] arr = new string[] { "zh-cn", "en-us" };
                if (!arr.Contains(language))
                    language = "zh-cn";
            }
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);
            System.Threading.Thread.CurrentThread.CurrentCulture = new
                 System.Globalization.CultureInfo(language);
        }
    }
}
