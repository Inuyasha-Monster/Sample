using Sample.Service.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample.Web.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountService _accountService;

        public HomeController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        // GET: Home
        public ActionResult Index()
        {
            var account = this._accountService.GetByName("djl");
            ViewData.Model = account.Name;
            return View();
        }
    }
}