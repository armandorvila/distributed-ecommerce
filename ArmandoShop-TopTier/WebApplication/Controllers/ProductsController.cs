using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArmandoShop.WebApplication.Models.Services;
using System.Web.Routing;
using ArmandoShop.WebApplication.Models.Application;
using ArmandoShop.WebApplication.Models.Application.Access;

namespace ArmandoShop.WebApplication.Controllers
{
    public class ProductsController : Controller
    {
        private DelegateProductsService service;

        protected override void Initialize(RequestContext requestContext)
        {
            service = new DelegateProductsService();
            base.Initialize(requestContext);
            if (Session["user"] == null)
                new FormsAuthenticationService().SignOut();
        }

        public ActionResult LoadProductByCategory(Category selected)
        {
            List<Product> products = service.GetProductsByCategory(selected.id);
            ViewData["Category"] = selected.name;
            return View("ProductsByCategory", products);
        }

        public ActionResult LoadMostWantedProducts()
        {
            return View("MostWantedProducts",new ProductsSelector().GetMostWamtedProducts(10));
        }

        public ActionResult AddToCart(Product selected)
        {
            return RedirectToAction("AddToCart", "Cart", selected);
        }

    }
}
