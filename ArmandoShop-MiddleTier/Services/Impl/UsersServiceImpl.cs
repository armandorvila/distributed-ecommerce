using System.Collections.Generic;
using ArmandoShop.Business;
using ArmandoShop.Model;
using ArmandoShop.Services.Contracts;

namespace ArmandoShop.Services.Impl
{
    /// <summary>
    /// Here is the implementation of UserServiceContract
    /// </summary>
    public partial class ArmandoShopService
    {
        public User Login(string username, string password)
        {
            return usersFacade.Login(username, password);
        }


        public bool IsUsernameAvaiable(string username)
        {
            return usersFacade.IsUserNameAvaiable(username);
        }

        public long NewUser(User user)
        {
            return usersFacade.CreateUser(user);
        }

        public void ModifyUser(User user)
        {
            usersFacade.ModifyUser(user);
        }

        public void DeleteUser(long id)
        {
            usersFacade.DeleteUser(id);
        }
    }

}