using ArmandoShop.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ArmandoShop.Model;
using System.Collections.Generic;

namespace ArmandoShop.DataAccess.Tests
{

    [TestClass()]
    public class ProviderDAOTest
    {
  
        private ICategoryAwareDAO<Provider> dao;

        [TestInitialize]
        public void setUp()
        {
            dao = new DataAccessFactory().GetProvidercategoryAwareDAO();
        }

        [TestMethod]
        public void TestFindById()
        {
            Console.WriteLine("Testing Getting Provider By Id: 1\n");
            Provider provider = dao.FindById(1);
            Console.WriteLine(provider);
            Console.WriteLine("End Test \n ______ \n\n");
        }

        [TestMethod]
        public void TestFindAllproviders()
        {
            Console.WriteLine("Testing Getting All providers: \n");
            IList<Provider> providers = dao.FindAll();
            foreach (Provider provider in providers)
                Console.WriteLine(provider);
            Console.WriteLine("End Test \n ______ \n\n");
        }

        [TestMethod]
        public void CreateTest()
        {
            Provider newProvider = dao.FindById(1);

            Console.WriteLine("Testing Create Provider : \n");
            Console.WriteLine("Current providers  : \n");
            IList<Provider> providers = dao.FindAll();
            foreach (Provider provider in providers)
                Console.WriteLine(provider);
            Console.WriteLine("Creating Provider  :" + newProvider.Name + "\n");
            dao.Create(newProvider);
            Console.WriteLine("Current providers  : \n");
            providers = dao.FindAll();
            foreach (Provider provider in providers)
                Console.WriteLine(provider);
            Console.WriteLine("End Test \n ______ \n\n");

        }

        [TestMethod]
        public void DeleteTest()
        {
            Console.WriteLine("Testing Delete Provider : \n");
            Console.WriteLine("Current providers  : \n");
            IList<Provider> providers = dao.FindAll();
            foreach (Provider provider in providers)
                Console.WriteLine(provider);
            Console.WriteLine("Deleting Last Providern");
            long id = providers[providers.Count - 1].Id;
            dao.Remove(id);
            Console.WriteLine("Current providers  : \n");
            providers = dao.FindAll();
            foreach (Provider provider in providers)
                Console.WriteLine(provider);
            Console.WriteLine("End Test \n ______ \n\n");
        }

        [TestMethod]
        public void UpdateTest()
        {
            Console.WriteLine("Testing Update Provider : \n");
            Console.WriteLine("Current providers  : \n");
            IList<Provider> providers = dao.FindAll();
            foreach (Provider provider in providers)
                Console.WriteLine(provider);
            Console.WriteLine("Updating Last Provider\n");
            Provider old = providers[providers.Count - 1];
            old.Name = this.RandomName();
            dao.Update(old);
            Console.WriteLine("Current providers  : \n");
            providers = dao.FindAll();
            foreach (Provider provider in providers)
                Console.WriteLine(provider);
            Console.WriteLine("End Test \n ______ \n\n");
        }
        [TestMethod]
        public void GetCategoriesByElementTest()
        {
            Console.WriteLine("Testing GetCategoriesByElementTest : \n");
            Provider provider = dao.FindById(1);
            IList<Category> categoritiesOfProvider = 
                                            dao.GetCategoriesByElement(provider);
             foreach (Category category in categoritiesOfProvider)
                 Console.WriteLine(category);
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
