using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LY.WeiXin.App.Areas.SysAdmin.Controllers
{
    public class MainController : Controller
    {
        // GET: SysAdmin/Main
        public ActionResult Index()
        {
            return View();
        }
    }
}