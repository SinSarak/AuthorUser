using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthorUser.Models.Claims
{
    public class CreateUserRoleClaimViewModel
    {
        public List<ApplicationUser> Users { get; set; }
        public List<AppClaim> AppClaims { get; set; }
    }
}