using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;
using System.ServiceModel;

namespace ArmandoShop.Services.Contracts
{
    [ServiceContract(Namespace = "http://ArmandoShop.UsersService")]
    public interface IUsersService
    {
        [OperationContract]
        User Login(string username, string password);

        [OperationContract]
        Boolean IsUsernameAvaiable(string username);

        [OperationContract]
        long NewUser(User user);

        [OperationContract]
        void ModifyUser(User user);

        [OperationContract]
        void DeleteUser(long id);

    }
}
