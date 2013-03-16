using ArmandoShop.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ArmandoShop.Model;
using System.Collections.Generic;

namespace ArmandoShop.DataAccess.Tests
{

    [TestClass()]
    public class OrderDAOTest
    {

        private IProductAwareDAO<Order> dao;

        [TestInitialize]
        public void setUp()
        {
            dao = new DataAccessFactory().GetOrderProductAwareDAO();
        }

        [TestMethod]
        public void TestFindById()
        {
            Console.WriteLine("Testing Getting order By Id: 1\n");
            Order order = dao.FindById(6);
            Console.WriteLine(order);
            Console.WriteLine("End Test \n ______ \n\n");
        }

        [TestMethod]
        public void TestFindAllorders()
        {
            Console.WriteLine("Testing Getting All orders: \n");
            IList<Order> orders = dao.FindAll();
            foreach (Order order in orders)
                Console.WriteLine(order);
            Console.WriteLine("End Test \n ______ \n\n");
        }

        [TestMethod]
        public void CreateTest()
        {
            Product product = new Product();
            product.Id = 1;
            Order neworder = new Order();
            neworder.Amounts = new Dictionary<long, int>();
            neworder.addProduct(product);
            neworder.Amounts.Add(1,1);
            neworder.DateOfBuy = DateTime.Now;
            neworder.DateOfDeliver = DateTime.Now;
            neworder.Delivered = false;
            neworder.Customer = new Customer();
            neworder.Customer.Id = 1;

            dao.Create(neworder);
            Console.WriteLine("Current orders  : \n");
           

            Console.WriteLine("End Test \n ______ \n\n");

        }

        [TestMethod]
        public void DeleteTest()
        {
            Console.WriteLine("Testing Delete order : \n");
            Console.WriteLine("Current orders  : \n");
            IList<Order> orders = dao.FindAll();
            foreach (Order order in orders)
                Console.WriteLine(order);
            Console.WriteLine("Deleting Last ordern");
            long id = orders[orders.Count - 1].Id;
            dao.Remove(id);
            Console.WriteLine("Current orders  : \n");
            orders = dao.FindAll();
            foreach (Order order in orders)
                Console.WriteLine(order);
            Console.WriteLine("End Test \n ______ \n\n");
        }

        [TestMethod]
        public void UpdateTest()
        {
            Console.WriteLine("Testing Update order : \n");
            Console.WriteLine("Current orders  : \n");
            IList<Order> orders = dao.FindAll();
            foreach (Order order in orders)
                Console.WriteLine(order);
            Console.WriteLine("Updating Last order\n");
            Order old = orders[orders.Count - 1];
            old.Delivered = true;
            dao.Update(old);
            Console.WriteLine("Current orders  : \n");
            orders = dao.FindAll();
            foreach (Order order in orders)
                Console.WriteLine(order);
            Console.WriteLine("End Test \n ______ \n\n");
        }

        [TestMethod]
        public void GetProductsByElementTest()
        {
            Console.WriteLine("GetProductsByElementTest : \n");
            Order order = dao.FindById(6);
            IList<Product> productsOfOrder = dao.GetProductsByElement(order);

            foreach (Product product in productsOfOrder)
                Console.WriteLine(product);

            Console.WriteLine("End Test \n ______ \n\n");
        }

    }
}
