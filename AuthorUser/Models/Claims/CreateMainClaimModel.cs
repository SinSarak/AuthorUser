using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthorUser.Models.Claims
{
    public class CreateMainClaimModel
    {
        public string Name { get; set; }
        public int SubClaimId { get; set; }
    }
}