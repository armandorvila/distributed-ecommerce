using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArmandoShop.WebApplication.Models.Model;
using ArmandoShop.WebApplication.Models.Services;
using System.Web.Routing;
using ArmandoShop.WebApplication.Models.Application;
using ArmandoShop.WebApplication.Models.Application.Access;

namespace ArmandoShop.WebApplication.Controllers
{

    public class CartController : Controller
    {

        private static readonly string CART_SESSION_KEY = "Cart";

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["user"] == null)
                new FormsAuthenticationService().SignOut();

        }

        public ActionResult LoadCart()
        {
            /*By default view will be LoadCart, as this method :)*/
            return View("Cart", this.GetCart());
        }

        public ActionResult AddToCart(Product toAdd)
        {
            Cart cart = this.GetCart();
            cart.AddProduct(toAdd);
            Session.Add(CART_SESSION_KEY, cart);

            return View("Cart", cart);
        }

        public ActionResult AddUnit(Product toAddUnit)
        {
            Cart cart = this.GetCart();
            if (cart.Amounts[toAddUnit.id] < toAddUnit.stock)
            {

                cart.AddProduct(toAddUnit);
                Session.Add(CART_SESSION_KEY, cart);
            }
            else
            {
                ModelState.
                          AddModelError("", "There is n't enough stock..");
            }
            return View("Cart", cart);
        }

        public ActionResult RemoveOfCart(Product selected)
        {
            Cart Cart = this.GetCart();
            Cart.RemoveProduct(selected.id);
            Session.Add(CART_SESSION_KEY, Cart);


            return View("Cart", Cart);
        }

        public ActionResult DecrementUnits(Product product)
        {
            Cart Cart = this.GetCart();
            Cart.DecrementAmount(product.id);
            Session.Add(CART_SESSION_KEY, Cart);
            return View("Cart", Cart);
        }

        public ActionResult CleanCart()
        {
            Session[CART_SESSION_KEY] = null;
            return View("Cart", this.GetCart());
        }

        public ActionResult BuyCart()
        {

            Cart cart = this.GetCart();
            if (cart.Products.Count > 0)
            {
                User user = (User)Session["user"];
                long id = Broker.GetBroker().ProcessCart(cart, user);
                this.CleanCart();
                ViewData["OrderId"] = id;
                return View("Confirmation");
            }
            else
            {
                ModelState.
                           AddModelError("", "You must select any product!!");
                return View("Cart", cart);
            }
        }

        private Cart GetCart()
        {
            Cart Cart = (Cart)Session[CART_SESSION_KEY];

            if (Cart == null)
                Cart = new Cart();

            return Cart;
        }

    }
}
