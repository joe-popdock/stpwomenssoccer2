using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using stpwomenssoccer2.Models;

namespace stpwomenssoccer2.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext db;

        public RoleController()
        {
            db = new ApplicationDbContext();
        }
        
        /// <summary>  
        /// Get All Roles  
        /// </summary>  
        /// <returns></returns>  
        public ActionResult Index()
        {
            var Roles = db.Roles.ToList();
            return View(Roles);
        }

        /// <summary>  
        /// Create  a New role  
        /// </summary>  
        /// <returns></returns>  
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        /// <summary>  
        /// Create a New Role  
        /// </summary>  
        /// <param name="Role"></param>  
        /// <returns></returns>  
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            db.Roles.Add(Role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}