using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArmandoShop.WebApplication.Models.Services
{
    public class DelegateUsersService
    {
       

        public User Login(string username, string password)
        {
            User user = null;
            using (UsersServiceClient client = new UsersServiceClient())
            {
                user = client.Login(username, password);
            }
            return user;
        }

        public long  NewUser(User user)
        {
            long id = -1;
            using (UsersServiceClient client = new UsersServiceClient())
            {
                id = client.NewUser(user);
            }

            return id;
        }

    }
}