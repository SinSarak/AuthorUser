using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthorUser.Models.Claims
{
    public class CreateUserRoleClaimModel
    {
        public string User { get; set; }
        public string AppClaim { get; set; }
    }
}