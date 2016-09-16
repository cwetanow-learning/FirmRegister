using FirmRegister.Web.Controllers.Abstract;
using Microsoft.AspNet.Identity;
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
    }
}