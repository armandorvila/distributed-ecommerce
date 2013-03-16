using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;
using ArmandoShop.Business.Providers;

namespace ArmandoShop.Business.Categories
{
    class CategoriesFacadeImpl: ICategoriesFacade
    {
        private CategoriesSupplier categoriesSupplier;
        private CategoriesManager categoriesManager;
       

        public IList<Category> ListCategories()
        {
            return categoriesSupplier.GetAllCategories();
        }

        public IList<Category> GetCategoriesByProvider(long idProvider)
        {
            return categoriesSupplier.GetCategoriesByProvider(idProvider);
        }

        public void AddProviderToCategory(long idProvider, long idcategory)
        {
            categoriesManager.AddProvider(idProvider,idcategory);
        }

        public void RemoveProviderOfCategory(long idProvider, long idcategory)
        {
            categoriesManager.RemoveProvider(idProvider, idcategory);
        }

        public Category GetCategory(long id)
        {
            return categoriesSupplier.GetCategory(id);
        }

        public long NewCategory(Category category)
        {
            return categoriesManager.Createcategory(category);
        }

        public void DeleteCategory(long id)
        {
            categoriesManager.Deletecategory(id);
        }

        public void ModifyCategory(Category category)
        {
            categoriesManager.Modifycategory(category);
        }
        

        public IList<Category> GetCategoriesNotInProvider(long idProvider)
        {
            return categoriesSupplier.GetCategoriesNotInProvider(idProvider);
        }

    }
}
