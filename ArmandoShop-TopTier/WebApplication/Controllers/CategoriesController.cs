using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ArmandoShop.WebApplication.Models.Services;
using ArmandoShop.WebApplication.Models.Application.Access;

namespace ArmandoShop.WebApplication.Controllers
{
    [HandleError]
    public class CategoriesController : Controller
    {
        private DelegateCategoriesService service;

        protected override void Initialize(RequestContext requestContext)
        {
            service = new DelegateCategoriesService();
            base.Initialize(requestContext);
            if (Session["user"] == null)
                new FormsAuthenticationService().SignOut();
        }

        public ActionResult ShowProducts(Category selected)
        {
            return RedirectToAction("LoadProductByCategory", "Products", selected);
        }


        public ActionResult LoadCategories()
        {
            return View("Categories", service.ListCategories());
        }

    }
}
