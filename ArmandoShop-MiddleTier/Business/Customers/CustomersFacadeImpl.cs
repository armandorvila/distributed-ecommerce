using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;
using ArmandoShop.DataAccess;

namespace ArmandoShop.Business.Customers
{
    public class CustomersFacadeImpl:ICustomersFacade
    {
        private IDAO<Customer> customerDAO;
        private IUserAwareDAO<Customer> customerUserAwareDAO;

        public Customer GetCustomer(long id)
        {
            return customerDAO.FindById(id);
        }

        public long CreateCustomer(Customer customer)
        {
            return customerDAO.Create(customer);
        }


        public IList<Customer> ListCustomers()
        {
            return customerDAO.FindAll();
        }

        public void ModifyCustomer(Customer customer)
        {
            customerDAO.Update(customer);
        }

        public void DeleteCustomer(long id)
        {
            customerDAO.Remove(id);
        }


        public Customer GetCustomer(User user)
        {
            return customerUserAwareDAO.GetElementByUser(user);
        }
    }
}
