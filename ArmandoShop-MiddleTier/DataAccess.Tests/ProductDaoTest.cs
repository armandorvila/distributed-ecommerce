using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArmandoShop.DataAccess;
using ArmandoShop.Model;

namespace ArmandoShop.DataAccess.Tests
{
    [TestClass]
    public class ProductDaoTest
    {
        private IDAO<Product> dao;

        [TestInitialize]
        public void setUp()
        {
            dao = new DataAccessFactory().GetProductDAO();
        }

        [TestMethod]
        public void TestFindById()
        {
            Console.WriteLine("Testing Getting Product By Id: 1\n");
            Product produt = dao.FindById(18);
            Console.WriteLine(produt);
            Console.WriteLine("End Test \n ______ \n\n");
        }

        [TestMethod]
        public void TestFindAllProducts()
        {
            Console.WriteLine("Testing Getting All Products: \n");
            IList<Product> products = dao.FindAll();
            foreach (Product product in products)
                Console.WriteLine(product);
            Console.WriteLine("End Test \n ______ \n\n");
        }

        [TestMethod]
        public void CreateTest()
        {
            Product newProduct = dao.FindById(22);

            Console.WriteLine("Testing Create Product : \n");
            Console.WriteLine("Current Products  : \n");
            IList<Product> products = dao.FindAll();
            foreach (Product product in products)
                Console.WriteLine(product);
            Console.WriteLine("Creating Product  :" + newProduct.Name + "\n");
            dao.Create(newProduct);
            Console.WriteLine("Current Products  : \n");
            products = dao.FindAll();
            foreach (Product product in products)
                Console.WriteLine(product);
            Console.WriteLine("End Test \n ______ \n\n");

        }

        [TestMethod]
        public void DeleteTest()
        {
            Console.WriteLine("Testing Delete Product : \n");
            Console.WriteLine("Current Products  : \n");
            IList<Product> products = dao.FindAll();
            foreach (Product product in products)
                Console.WriteLine(product);
            Console.WriteLine("Deleting Last Productn");
            long id = products[products.Count - 1].Id;
            dao.Remove(id);
            Console.WriteLine("Current Products  : \n");
            products = dao.FindAll();
            foreach (Product product in products)
                Console.WriteLine(product);
            Console.WriteLine("End Test \n ______ \n\n");
        }

        [TestMethod]
        public void UpdateTest()
        {
            Console.WriteLine("Testing Update Product : \n");
            Console.WriteLine("Current Products  : \n");
            IList<Product> products = dao.FindAll();
            foreach (Product product in products)
                Console.WriteLine(product);
            Console.WriteLine("Updating Last Product\n");
            Product old = products[products.Count - 1];
            old.Name = this.RandomName();
            dao.Update(old);
            Console.WriteLine("Current Products  : \n");
            products = dao.FindAll();
            foreach (Product product in products)
                Console.WriteLine(product);
            Console.WriteLine("End Test \n ______ \n\n");
        }


        private string RandomName()
        {
            Random random = new Random();
            int n = random.Next(1000000);
            return "name" + n;
        }

    }
}
