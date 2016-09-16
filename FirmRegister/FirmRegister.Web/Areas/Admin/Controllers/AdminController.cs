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
    public partial class AdminController : Controller
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

        public virtual ActionResult Index(int page = 1)
        {
            var users = this.UserManager.Users
                .ToList()
                .ToPagedList(page, GlobalConstants.PageSize);

            return View(users);
        }

        public virtual ActionResult Edit(string id)
        {
            var user = this.UserManager.FindById(id);

            return View(user);
        }

        [HttpPost]
        public virtual ActionResult Edit(ApplicationUser editedUser)
        {
            var user = this.UserManager.FindById(editedUser.Id);

            user.LastName = editedUser.LastName;
            user.FirstName = editedUser.FirstName;
            user.Age = editedUser.Age;
            user.Email = editedUser.Email;

            this.UserManager.Update(user);

            return RedirectToAction("Index");

        }

        [HttpPost]
        public virtual ActionResult Delete(string id)
        {
            var user = this.UserManager.FindById(id);

            this.UserManager.Delete(user);

            return View("Index");
        }

        [HttpPost]
        public ActionResult MakeAdmin(string id)
        {
            this.UserManager.AddToRole(id, GlobalConstants.OperatorRole);

            return View("Index");
        }

        [HttpPost]
        public ActionResult Unadmin(string id)
        {
            this.UserManager.RemoveFromRole(id, GlobalConstants.OperatorRole);

            return View("Index");
        }
    }
}
