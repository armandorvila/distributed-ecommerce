using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.DataAccess;
using ArmandoShop.Model;

namespace ArmandoShop.Business.Categories
{
    internal class CategoriesManager
    {

        private IDAO<Category> categoryDAO;
        private ICategoryAwareDAO<Provider> providerDAO;

        internal long Createcategory(Category category)
        {
            return categoryDAO.Create(category);
        }

        internal void Deletecategory(long id)
        {
            categoryDAO.Remove(id);
        }

        internal void Modifycategory(Category category)
        {
            categoryDAO.Update(category);
        }

        internal void AddProvider(long idProvider, long idcategory)
        {
            Category category = new Category();
            Provider provider = new Provider();
            category.Id = idcategory;
            provider.Id = idProvider;
            this.providerDAO.AddCatagorityToElement(category,provider);
        }

        internal void RemoveProvider(long idProvider, long idcategory)
        {
            Category category = new Category();
            Provider provider = new Provider();
            category.Id = idcategory;
            provider.Id = idProvider;
            this.providerDAO.RemoveCategoryOfElement(category,provider);
        }
    }
}
