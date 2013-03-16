using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;

namespace ArmandoShop.Services.Impl
{
  
    partial class ArmandoShopService
    {

        public Customer GetCustomer(long id)
        {
            return this.customersFacade.GetCustomer(id);
        }

        public Customer GetCustomerByUser(User user)
        {
            return this.customersFacade.GetCustomer(user);
        }

        public long NewCustomer(Customer customer)
        {
            return this.customersFacade.CreateCustomer(customer);
        }

        public IList<Customer> ListCustomers()
        {
            return customersFacade.ListCustomers();
        }

        public void ModifyCustomer(Customer customer)
        {
            customersFacade.ModifyCustomer(customer);
        }

        public void DeleteCustomer(long id)
        {
            customersFacade.DeleteCustomer(id);
        }
    }
}
