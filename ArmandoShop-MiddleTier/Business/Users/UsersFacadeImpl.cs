using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Business;
using ArmandoShop.Model;
using ArmandoShop.DataAccess;

namespace ArmandoShop.Business.Users
{
   public class UsersFacadeImpl : IUsersFacade
    {
       private IUserDAO userDAO;

        public User Login(string username, string password)
        {
            User user = null;
           
            if (username!=null || password!=null)
            {
                user = userDAO.FindByUsername(username);
                if (user != null)
                {
                    if (!user.Password.Equals(password))
                        user = null;
                }
            }
            return user;
        }


        public long CreateUser(User user)
        {
            return userDAO.Create(user);
        }

        public void ModifyUser(User user)
        {
            userDAO.Update(user);
        }

        public void DeleteUser(long id)
        {
            userDAO.Remove(id);
        }

        public bool IsUserNameAvaiable(string username)
        {
            User user = userDAO.FindByUsername(username);
            return user == null;
        }
    }
}
