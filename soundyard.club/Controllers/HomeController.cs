using club.soundyard.web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace club.soundyard.web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationUserManager _userManager;

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

        public async Task<ActionResult> Index()
        {

            using (var db = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();
                var user = await UserManager.FindByIdAsync(userId);
                var roles = await UserManager.GetRolesAsync(userId);
                foreach (var roleName in roles)
                {
                    var data = await db.ApplicationRoles.FirstOrDefaultAsync(r => r.Name == roleName);
                    if (data != null)
                    {
                        ViewBag.RoleDescription = data.Agreement;
                        break;
                    }
                    else
                        ViewBag.RoleDescription = "Without role";
                }
            }
            return View();
        }

        public ActionResult Report()
        {
            return View();
        }

        public ActionResult Administrace()
        {
            return View();
        }
    }
}