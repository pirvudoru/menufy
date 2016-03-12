using System.Linq;
using System.Web;
using System.Web.Mvc;
using MenufyServer.Data;
using MenufyServer.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace MenufyServer.Controllers
{
    public class MenuController : Controller
    {
        private MenuGenerator _menuGenerator;
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

        public MenuController()
        {
            _menuGenerator = new MenuGenerator();
        }
        
        // GET: Menu
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var profile = ApplicationDbContext.Create().Profiles
                .First(p => p.UserId == userId);
            
            var menu = _menuGenerator.Generate(profile);

            return View(menu);
        }
    }
}