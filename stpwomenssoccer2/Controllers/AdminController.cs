using stpwomenssoccer2.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace stpwomenssoccer2.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [AuthLog(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View();
        }
    }
}