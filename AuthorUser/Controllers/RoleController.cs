using AuthorUser.Models;
using AuthorUser.Models.Roles;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AuthorUser.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationRoleManager _roleManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext DB = new ApplicationDbContext();

        public RoleController() { }

        public RoleController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
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

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        // GET: Role
        public ActionResult Index()
        {
            List<RoleViewModel> list = new List<RoleViewModel>();
            foreach (var l in RoleManager.Roles)
            {
                list.Add(new RoleViewModel(l));

            }
            return View(list);
        }

        [HttpGet]
        public ActionResult AssignUserRole() {
            var model = new AssignUserRoleViewModel();
            model.Users = UserManager.Users.ToList();
            model.Roles = RoleManager.Roles.ToList();
            return View(model);
        }
        [HttpPost]
        [ActionName("AssignUserRole")]
        public ActionResult AssignUserRole_Post(AssignUserRoleModel model)
        {
            var oldUser = UserManager.FindById(model.User);
            var user = DB.Users.SingleOrDefault(p => p.Id == model.User);

            if (oldUser.Roles.Count != 0)
            {
                var oldRoleId = oldUser.Roles.SingleOrDefault().RoleId;
                var oldRoleName = DB.Roles.SingleOrDefault(r => r.Id == oldRoleId).Name;

                if (oldRoleName != model.Role)
                {
                    UserManager.RemoveFromRole(model.User, oldRoleName);
                    UserManager.AddToRole(model.User, model.Role);
                }
            }else
            {
                UserManager.AddToRole(model.User, model.Role);
            }

            
            DB.Entry(user).State = EntityState.Modified;

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<ActionResult> Create_Post(RoleViewModel model)
        {
            var role = new ApplicationRole() {Name = model.Name };
            await RoleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit (string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(role));
        }

        
        

    }
}