using AuthorUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AuthorUser.Models.Claims;
using Microsoft.AspNet.Identity.Owin;

namespace AuthorUser.Controllers
{
    public class AppClaimController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;

        public AppClaimController() { }
        public AppClaimController(ApplicationUserManager userManager)
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

        // GET: MainClaims
        public async Task<ActionResult> Index()
        {
            var mainClaims = db.AppClaims.Include(p=>p.SubClaim);
            return View(await mainClaims.ToListAsync());
        }

        public ActionResult Create()
        {
            var model = new CreateMainClaimViewModel();
            model.AppClaims = db.AppClaims.OrderBy(p => p.Name).Where(p => p.SubClaimId != 0 && p.Active == true).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateMainClaimModel mainClaim)
        {
            var model = new AppClaim();
            model.Name = mainClaim.Name;

            if (mainClaim.SubClaimId != 0)
            {
                model.SubClaimId = mainClaim.SubClaimId;
            }
            model.Active = true;

            db.AppClaims.Add(model);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult UserRoleClaim()
        {
            List<ClaimViewModel> list = new List<ClaimViewModel>();
            foreach (var u in UserManager.Users.ToList())
            {
                foreach (var role in u.Claims.ToList())
                {
                    list.Add(new ClaimViewModel { Email = u.Email, ClaimValue = role.ClaimValue, ClaimType = role.ClaimType });
                }

            }
            return View(list);
        }

    }
}