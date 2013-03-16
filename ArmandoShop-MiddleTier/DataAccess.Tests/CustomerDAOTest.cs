using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ArmandoShop.Model;
using System.Collections.Generic;


namespace ArmandoShop.DataAccess.Tests
{

    [TestClass()]
    public class CustomerDAOTest
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        private static IDAO<Customer> target;
        private static Customer element;
  
        [TestInitialize]
        public void setUpAll(){
            target = new DataAccessFactory().GetCustomerDAO();
            element = new Customer();
            element.Id = 1;
            element.Name = "Lucatoni";
            element.Surname = "Lucoanon";
            element.Address = "La polla street";
            element.Phone = "penpon";
            element.Mail = "Mail";
 
        }

        

        [TestMethod()]
        public void FindByIdTest()
        {
            long id = 1;
            Customer cutomer = target.FindById(id);
            Console.WriteLine("Customer:" + cutomer);
        }

        [TestMethod()]
        public void FindAllTest()
        {
            IList<Customer> customers = target.FindAll();
            Console.WriteLine("Al customers are:\n");
            foreach (Customer customer in customers)
            Console.WriteLine(customer);
        }


        [TestMethod()]
        public void CreateTest()
        {
            User user = new User();
            user.Id = 1;
            element.User = user;
            long id = target.Create(element);
            Console.WriteLine("New Id :" + id);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            User user = new User();
            user.Id = 1;
            element.User = user;
            //element.Phone = "asdasd";
            Console.WriteLine("Before :" + target.FindById(element.Id));
            target.Update(element);
            Console.WriteLine("After :" + target.FindById(element.Id));

        }


        [TestMethod()]
        public void RemoveTest()
        {
            long id = 2;
            target.Remove(id);
            IList<Customer> customers = target.FindAll();
            Console.WriteLine("Al customers are:\n");
            Console.WriteLine(customers);
        }
    }
}
