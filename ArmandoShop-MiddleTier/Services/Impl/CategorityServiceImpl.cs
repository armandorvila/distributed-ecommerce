using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;

namespace ArmandoShop.Services.Impl
{
    partial class ArmandoShopService
    {
        public IList<Category> ListCategories()
        {
           return categoryFacade.ListCategories();
        }

        public IList<Category> GetCategoriesByProvider(long idProvider)
        {
           return categoryFacade.GetCategoriesByProvider(idProvider);
        }

        public IList<Category> GetCategoriesNotInProvider(long idProvider)
        {
            return categoryFacade.GetCategoriesNotInProvider(idProvider);
        }

        public void AddProviderToCategory(long idProvider, long idcategory)
        {
            categoryFacade.AddProviderToCategory(idProvider, idcategory);
        }

        public void RemoveProviderOfCategory(long idProvider, long idcategory)
        {
            categoryFacade.RemoveProviderOfCategory(idProvider , idcategory);
        }

        public Category GetCategory(long id)
        {
            return categoryFacade.GetCategory(id);
        }

        public long NewCategory(Category category)
        {
            return categoryFacade.NewCategory(category);
        }

        public void DeleteCategory(long id)
        {
            categoryFacade.DeleteCategory(id);
        }

        public void ModifyCategory(Category category)
        {
            categoryFacade.ModifyCategory(category);
        }
    }
}
