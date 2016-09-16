using FirmRegister.Domain.Models;
using FirmRegister.Domain.Utils;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace FirmRegister.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Operator")]
    [RouteArea]
    public class AdminController : Controller
    {
        protected ApplicationUser currentUser;
        protected ApplicationUserManager userManager;

        public ApplicationUser CurrentUser
        {
            get
            {
                return this.currentUser ?? this.UserManager.FindById(Thread.CurrentPrincipal.Identity.GetUserId());
            }
            private set
            {
                this.currentUser = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return this.userManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                this.userManager = value;
            }
        }

        public ActionResult Index(int page = 1)
        {
            var users = this.UserManager.Users
                .ToList()
                .ToPagedList(page, GlobalConstants.PageSize);

            return View(users);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
