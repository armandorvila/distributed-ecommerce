using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using ArmandoShop.WebApplication.Models.Application.Access;
using ArmandoShop.WebApplication.Models.Application.Access.Validation;
using ArmandoShop.WebApplication.Models.Model;
using ArmandoShop.WebApplication.Models.Services;

namespace ArmandoShop.WebApplication.Controllers
{

    [HandleError]
    public class AccessController : Controller
    {

        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccessMembershipService(); }
            
            base.Initialize(requestContext);

            if (Session["user"] == null)
                FormsService.SignOut();

        }


        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                if (MembershipService.ValidateUser(model.UserName, model.Password))
                {
                    FormsService.SignIn(model.UserName, model.RememberMe);
                    Session["user"] = new DelegateUsersService()
                        .Login(model.UserName, model.Password);
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("LoadHome", "Info");
                    }
                }
                else
                {
                    ModelState.
                        AddModelError("", "Invalid password or username!!");
                }
            }

            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsService.SignOut();

            return RedirectToAction("LoadHome", "Info");
        }

        public ActionResult Register()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User user = new User();
                    user.username = model.UserName;
                    user.password = model.Password;
                    user.id = new DelegateUsersService().NewUser(user);

                    Customer customer = new Customer();
                    customer.name = model.Name;
                    customer.surname = model.Surname;
                    customer.address = model.Address;
                    customer.mail = model.Email;
                    customer.phone = model.Phone;
                    customer.user = user;
                    customer.id = new DelegateCustomersService().NewCustomer(customer);



                    FormsService.SignIn(model.UserName, false);
                    return RedirectToAction("LoadHome", "Info");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", AccessValidation.
                                                 ErrorCodeToString(MembershipCreateStatus.UserRejected));
                }
            }

            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }


    }
}
