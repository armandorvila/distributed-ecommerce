using ArmandoShop.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ArmandoShop.Model;
using System.Collections.Generic;

namespace ArmandoShop.DataAccess.Tests
{
    
    [TestClass()]
    public class CategoryDAOTest
    {

        private IProviderAwareDAO<Category> dao;

        [TestInitialize]
        public void setUp()
        {
            dao = new DataAccessFactory().GetCategoryProviderAwareDAO();
        }

       // [TestMethod]
        public void TestFindById()
        {
            Console.WriteLine("Testing Getting category By Id: 1\n");
            Category category = dao.FindById(1);
            Console.WriteLine(category);
            Console.WriteLine("End Test \n ______ \n\n");
        }

       // [TestMethod]
        public void TestFindAllcategorys()
        {
            Console.WriteLine("Testing Getting All categorys: \n");
            IList<Category> categorys = dao.FindAll();
            foreach (Category category in categorys)
                Console.WriteLine(category);
            Console.WriteLine("End Test \n ______ \n\n");
        }

       // [TestMethod]
        public void CreateTest()
        {
            Category newcategory = dao.FindById(1);

            Console.WriteLine("Testing Create category : \n");
            Console.WriteLine("Current categorys  : \n");
            IList<Category> categorys = dao.FindAll();
            foreach (Category category in categorys)
                Console.WriteLine(category);
            Console.WriteLine("Creating category  :" + newcategory.Name + "\n");
            dao.Create(newcategory);
            Console.WriteLine("Current categorys  : \n");
            categorys = dao.FindAll();
            foreach (Category category in categorys)
                Console.WriteLine(category);
            Console.WriteLine("End Test \n ______ \n\n");

        }

      //  [TestMethod]
        public void DeleteTest()
        {
            Console.WriteLine("Testing Delete category : \n");
            Console.WriteLine("Current categorys  : \n");
            IList<Category> categorys = dao.FindAll();
            foreach (Category category in categorys)
                Console.WriteLine(category);
            Console.WriteLine("Deleting Last categoryn");
            long id = categorys[categorys.Count - 1].Id;
            dao.Remove(id);
            Console.WriteLine("Current categorys  : \n");
            categorys = dao.FindAll();
            foreach (Category category in categorys)
                Console.WriteLine(category);
            Console.WriteLine("End Test \n ______ \n\n");
        }

       // [TestMethod]
        public void UpdateTest()
        {
            Console.WriteLine("Testing Update category : \n");
            Console.WriteLine("Current categorys  : \n");
            IList<Category> categorys = dao.FindAll();
            foreach (Category category in categorys)
                Console.WriteLine(category);
            Console.WriteLine("Updating Last category\n");
            Category old = categorys[categorys.Count - 1];
            old.Name = this.RandomName();
            dao.Update(old);
            Console.WriteLine("Current categorys  : \n");
           categorys = dao.FindAll();
            foreach (Category category in categorys)
                Console.WriteLine(category);
            Console.WriteLine("End Test \n ______ \n\n");
        }

        //[TestMethod]
        public void GetProvidersByElementTest()
        {
            Console.WriteLine("GetProvidersByElementTest : \n");
            Category category = dao.FindById(1);
            IList<Provider> providersOfCateogirity = dao.GetProvidersByElement(category);

            foreach (Provider provider in providersOfCateogirity)
                Console.WriteLine(provider);

            Console.WriteLine("End Test \n ______ \n\n");
        }

        private string RandomName()
        {
            Random random = new Random();
            int n = random.Next(1000000);
            return "name" + n;
        }
        
        [TestMethod]
        public void CreateLotTest()
        {
            Category newcategory = new Category();

            for (int i = 0; i < 20; i++)
            {
                newcategory.Name = RandomName();
                newcategory.Description = RandomName();
                dao.Create(newcategory);
            }
              Console.WriteLine("Current categorys  : \n");
              IList<Category> categorities = dao.FindAll();
              foreach (Category category in categorities)
                  Console.WriteLine(category);
              Console.WriteLine("End Test \n ______ \n\n");          
        }
    }
}