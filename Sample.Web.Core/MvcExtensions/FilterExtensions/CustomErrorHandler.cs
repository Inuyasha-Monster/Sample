using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sample.Web.Core.MvcExtensions.FilterExtensions
{
    public class CustomErrorHandler : System.Web.Mvc.HandleErrorAttribute
    {


        public override void OnException(ExceptionContext filterContext)
        {

        }
    }
}
