using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace IdentityServerAspNetIdentity.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser<int>
    {
        public Guid UserId { get; set; }
        public string Salt { get; set; }
        public string VatCode { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
