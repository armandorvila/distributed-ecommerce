using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;

namespace ArmandoShop.Business
{
   public interface IUsersFacade
    {

       User Login(string username, string password);

       long CreateUser(User user);

       void ModifyUser(User user);

       void DeleteUser(long id);

       bool IsUserNameAvaiable(string username);
    }
}
