using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Ninject.Helper.Interfaces;

namespace Mvc_Ninject.Controllers
{
    public class HomeController : Controller
    {
        private IMessageHelper _iMessageHelper;

        public HomeController(IMessageHelper iMessageHelper)
        {
            _iMessageHelper = iMessageHelper;
        }

        public ActionResult Index()
        {
            ViewBag.Message = _iMessageHelper.GetWelcomeMessage();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
