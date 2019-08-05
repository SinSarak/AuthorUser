using AuthorUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthorUser.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /*
         * Return View or Customzie Unauthorize Page
         * 
         */
        [CustomizeAuthorize(Roles = "Claim1,SubClaim 1.1")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "Claim1,SubClaim 1.2")]
        public ActionResult Contact()
        {
            
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = "Admin,Claim1,SubClaim 1.3")]
        public ActionResult AllRole()
        {

            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}