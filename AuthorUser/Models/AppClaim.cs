using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorUser.Models
{
    public class AppClaim
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int ChildAppClaimId { get; set; }

        [ForeignKey("ChildAppClaimId")]
        public AppClaim ChildAppClaim { get; set; }
    }
}