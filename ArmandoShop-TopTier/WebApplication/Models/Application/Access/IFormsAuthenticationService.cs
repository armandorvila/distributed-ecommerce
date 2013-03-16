using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmandoShop.WebApplication.Models.Application.Access
{
    /// <summary>
    /// This Interface was adapted from Default MVC2 Project of VS10
    /// </summary>
    public interface IFormsAuthenticationService
    {
        void SignIn(string userName, bool createPersistentCookie);
        
        void SignOut();
    }
}
