using FirmRegister.Domain.Utils.Enumerations;
using FirmRegister.Web.Controllers.Abstract;
using FirmRegister.Web.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirmRegister.Web.Controllers
{
    public partial class HomeController : BaseController
    {
        public virtual ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ViewResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(SearchViewModel model)
        {
            var result = this.UserManager.Users;

            if (!string.IsNullOrEmpty(model.Name))
            {
                result = result
                    .Where(x => x.FirstName.Contains(model.Name)
                                || x.LastName.Contains(model.Name));
            }

            if (model.StartAge > 0)
            {
                result = result
                    .Where(x => x.Age >= model.StartAge);
            }

            if (model.EndAge > 0)
            {
                result = result
                    .Where(x => x.Age <= model.EndAge);
            }

            if (model.Gender != GenderType.NotSet)
            {
                result = result
                    .Where(x => x.Gender == model.Gender);
            }

            return View("Results", result);
        }
    }
}