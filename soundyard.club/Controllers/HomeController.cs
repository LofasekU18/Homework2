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
                    // Check the role in ApplicationRoles table
                    var data = await db.ApplicationRoles.FirstOrDefaultAsync(r => r.Name == roleName);
                    if (data != null)
                    {
                        ViewBag.RoleDescription = data.Agreement; // Access custom property
                        break; // Exit loop once role data is found, assuming one role should suffice
                    }
                    else
                        ViewBag.RoleDescription = "Without role";
                }
                // Query your database
                // Pass data to your view
            }
            return View();
        }

        public ActionResult Report()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Administrace()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}