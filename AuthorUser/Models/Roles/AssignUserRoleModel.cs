using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthorUser.Models.Roles
{
    public class AssignUserRoleModel
    {
        public string User { get; set; }
        public string Role { get; set; }
    }
}