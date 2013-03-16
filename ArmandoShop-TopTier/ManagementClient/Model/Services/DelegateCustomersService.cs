using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmandoShop.ManagementClient.Model.Services
{
    class DelegateCustomersService
    {
        public List<Customer> ListCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using (CustomersServiceClient client = new CustomersServiceClient())
            {
                customers = client.ListCustomers();
            }
            return customers;
        }


        public long NewCustomer(Customer customer)
        {
            long id = -1;
            using (CustomersServiceClient client = new CustomersServiceClient())
            {
                id = client.NewCustomer(customer);
            }
            return id;
        }


        public void ModifyCustomer(Customer customer)
        {
            using (CustomersServiceClient client = new CustomersServiceClient())
            {
                client.ModifyCustomer(customer);
            }
        }

        public void DeleteCustomer(long id)
        {
            using (CustomersServiceClient client = new CustomersServiceClient())
            {
                client.DeleteCustomer(id);
            }
        }
    }
}
