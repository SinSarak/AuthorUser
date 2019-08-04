using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthorUser.Models.Claims
{
    public class ClaimViewModel
    {
        public string Email { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

    }
}