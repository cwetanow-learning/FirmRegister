using FirmRegister.Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace FirmRegister.Web.Controllers.Abstract
{
    public abstract class BaseController : Controller
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

    }
}