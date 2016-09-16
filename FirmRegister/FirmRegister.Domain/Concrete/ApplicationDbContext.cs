using FirmRegister.Domain.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace FirmRegister.Domain.Concrete
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
