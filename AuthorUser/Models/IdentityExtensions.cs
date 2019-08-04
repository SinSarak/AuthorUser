using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace AuthorUser.Models
{
    public static class IdentityExtensions
    {
        /*User.Identity.GetFullname()
         * 
         * For usage in View
         * 
         * But we must assign Fullname as claim to the user
         */
        public static string GetFullname(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Fullname");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}