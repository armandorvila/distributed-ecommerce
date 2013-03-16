using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmandoShop.ManagementClient.Model.Services
{
    class DelegateUsersService
    {

   
        public long NewUser(User user)
        {
            long newId = -1;
            using (UsersServiceClient client = new UsersServiceClient())
            {
                newId = client.NewUser(user);
            }
            return newId;
        }

        public void ModifyUser(User user)
        {
            using (UsersServiceClient client = new UsersServiceClient())
            {
                client.ModifyUser(user);
            }
        }

        public void DeleteUser(long id)
        {
            using (UsersServiceClient client = new UsersServiceClient())
            {
                client.DeleteUser(id);
            }
        }


        public bool IsUsernameAvaiable(string username)
        {
            Boolean avaiable = false;
            using (UsersServiceClient client = new UsersServiceClient())
            {
                avaiable = client.IsUsernameAvaiable(username);
            }

            return avaiable;
        }
    }
}
