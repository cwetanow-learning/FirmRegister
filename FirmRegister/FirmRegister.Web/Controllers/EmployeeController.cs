using FirmRegister.Domain.Models;
using FirmRegister.Web.Controllers.Abstract;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Web.Mvc;

namespace FirmRegister.Web.Controllers
{
    public class EmployeeController : BaseController
    {
        public ActionResult Details(string id)
        {
            var user = this.UserManager.FindById(id);

            return View(user);
        }

        public FileContentResult GetImage(string id)
        {
            var user = this.UserManager.FindById(id);

            if (user != null)
            {
                return File(user.ImageData, user.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        public ActionResult Edit()
        {
            var user = this.CurrentUser;

            return View(user);
        }

        [HttpPost]
        public virtual ActionResult Edit(ApplicationUser editedUser, HttpPostedFileBase image = null)
        {
            if (image != null)
            {
                this.CurrentUser.ImageMimeType = image.ContentType;
                this.CurrentUser.ImageData = new byte[image.ContentLength];
                image.InputStream.Read(this.CurrentUser.ImageData, 0,
                image.ContentLength);
            }

            this.CurrentUser.LastName = editedUser.LastName;
            this.CurrentUser.FirstName = editedUser.FirstName;
            this.CurrentUser.Age = editedUser.Age;
            this.CurrentUser.Email = editedUser.Email;

            this.UserManager.Update(this.CurrentUser);

            return RedirectToAction("Details", new { id = this.CurrentUser.Id });
        }
    }
}