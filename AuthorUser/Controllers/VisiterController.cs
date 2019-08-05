using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthorUser.Controllers
{
    [Authorize(Roles ="Admin")]
    public class VisiterController : Controller
    {
        private ApplicationUserManager _userManager;
        public VisiterController() { }
        public VisiterController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Visiter
        public ActionResult Index()
        {
            var model = UserManager.Users.ToList();
            return View(model);
        }
    }
}