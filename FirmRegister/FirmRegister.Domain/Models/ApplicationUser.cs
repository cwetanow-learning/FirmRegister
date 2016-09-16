using FirmRegister.Domain.Contracts.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using FirmRegister.Domain.Utils.Enumerations;
using System;

namespace FirmRegister.Domain.Models
{
    public class ApplicationUser : IdentityUser, IApplicationUser
    {
        [Required]
        [Range(0, 150, ErrorMessage = "Please provide valid age")]
        public int Age
        {
            get; set;
        }

        [Required]
        public string FirstName
        {
            get; set;
        }

        public GenderType Gender
        {
            get; set;
        }

        [Required]
        public string LastName
        {
            get; set;
        }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
