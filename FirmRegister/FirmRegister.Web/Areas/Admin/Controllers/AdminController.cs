using FirmRegister.Domain.Models;
using FirmRegister.Domain.Utils;
using FirmRegister.Web.Controllers.Abstract;
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
    public partial class AdminController : BaseController
    {
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
        public virtual ActionResult Edit(ApplicationUser editedUser, HttpPostedFileBase image = null)
        {
            var user = this.UserManager.FindById(editedUser.Id);

            if (image != null)
            {
                user.ImageMimeType = image.ContentType;
                user.ImageData = new byte[image.ContentLength];
                image.InputStream.Read(user.ImageData, 0,
                image.ContentLength);
            }

            user.LastName = editedUser.LastName;
            user.FirstName = editedUser.FirstName;
            user.Age = editedUser.Age;
            user.Email = editedUser.Email;

            this.UserManager.Update(user);

            return RedirectToAction("Index");

        }
        
        public virtual ActionResult Delete(string id)
        {
            var user = this.UserManager.FindById(id);

            this.UserManager.Delete(user);

            return RedirectToAction("Index");
        }

        public ActionResult MakeAdmin(string id)
        {
            this.UserManager.AddToRole(id, GlobalConstants.OperatorRole);

            return RedirectToAction("Index");
        }

        public ActionResult Unadmin(string id)
        {
            this.UserManager.RemoveFromRole(id, GlobalConstants.OperatorRole);

            return RedirectToAction("Index");
        }
    }
}
