using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Unconference.Core.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        // -----------------------------------------------------------------------
        // Commented out by: Nicolò Carandini
        // Reason..........: Copied from old ASP.NET site
        // TODO............: Check if needed anymore and if still valid
        // -----------------------------------------------------------------------
        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    // Add custom user claims here
        //    userIdentity.AddClaim(new Claim("FullName", string.Concat(FirstName, " ", LastName)));
        //    return userIdentity;
        //}
        // -----------------------------------------------------------------------

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Fullname { get { return string.Concat(FirstName, " ", LastName); } }
    }
}
