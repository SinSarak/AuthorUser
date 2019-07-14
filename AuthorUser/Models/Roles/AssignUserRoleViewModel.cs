using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthorUser.Models.Roles
{
    public class AssignUserRoleViewModel
    {
        public List<ApplicationRole> Roles { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}