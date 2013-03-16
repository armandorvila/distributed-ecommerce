using System.Collections.Generic;
using System.ServiceModel;
using ArmandoShop.Model;

namespace ArmandoShop.Services.Contracts
{
    [ServiceContract (Namespace = "http://ArmandoShop.CustomersService")]
    public interface ICustomersService
    {
        [OperationContract]
        Customer GetCustomer(long id);

        [OperationContract]
        Customer GetCustomerByUser(User user);

        [OperationContract]
        IList<Customer> ListCustomers();

        [OperationContract]
        long NewCustomer(Customer customer);

        [OperationContract]
        void ModifyCustomer(Customer customer);

        [OperationContract]
        void DeleteCustomer(long id);
    }
}
