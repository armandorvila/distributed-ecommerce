using System.Web.Mvc;
using ArmandoShop.WebApplication.Models.Model;
using ArmandoShop.WebApplication.Models.Application;
using ArmandoShop.WebApplication.Models.Application.Access;
using System.Web.Routing;

namespace ArmandoShop.WebApplication.Controllers
{
    [HandleError]
    public class InfoController : Controller
    {


        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["user"] == null)
                new FormsAuthenticationService().SignOut();
           
        }

        public ActionResult LoadHome()
        {
            StaticsModel statics = new StatsSummaryBuilder().BuildStaticsModel();
    
            return View("Home",statics);
        }

        public ActionResult LoadContact()
        {
            return View("Contact");
        }
    }
}
