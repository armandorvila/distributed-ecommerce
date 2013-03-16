using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArmandoShop.WebApplication.Models.Services
{
    public class DelegateCustomersService
    {

        
        public Customer GetCustomer(long id)
        {
            using (CustomersServiceClient client = new CustomersServiceClient())
            {
                return client.GetCustomer(id);
            }
        }

        public long NewCustomer(Customer customer)
        {
            using (CustomersServiceClient client = new CustomersServiceClient())
            {
                return client.NewCustomer(customer);
            }
        }


        public Customer GetCustomerByUser(User user)
        {
            using (CustomersServiceClient client = new CustomersServiceClient())
            {
                return client.GetCustomerByUser(user);
            }
        }

    }
}