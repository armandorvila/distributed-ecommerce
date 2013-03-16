using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.ProvidersClient.Model.Services;

namespace ArmandoShop.ProvidersClient.Model
{
   public class UsersBusinessDelegate
    {
        public User Login(string username, string password)
        {
            using (UsersServiceClient client = new UsersServiceClient())
            {
                User user = client.Login(username, password);
                return user;
            }
        }


        public bool IsUsernameAvaiable(string username)
        {
            using (UsersServiceClient client = new UsersServiceClient())
            {
                return client.IsUsernameAvaiable(username);
            }
        }

        public void ModifyUser(User user)
        {
            using (UsersServiceClient client = new UsersServiceClient())
            {
                 client.ModifyUser(user);
            }
        }

    }
}
