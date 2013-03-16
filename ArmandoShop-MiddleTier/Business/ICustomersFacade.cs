using System.Collections.Generic;
using ArmandoShop.Model;

namespace ArmandoShop.Business
{
    public interface ICustomersFacade
    {
        Customer GetCustomer(long id);

        Customer GetCustomer(User user);

        IList<Customer> ListCustomers();

        long CreateCustomer(Customer customer);

        void ModifyCustomer(Customer customer);

        void DeleteCustomer(long id);
    }
}
