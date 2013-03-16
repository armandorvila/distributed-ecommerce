using System.Collections.Generic;
using ArmandoShop.DataAccess;
using ArmandoShop.Model;
using System.Linq;

namespace ArmandoShop.Business.Categories
{
    internal class CategoriesSupplier
    {
        private IDAO<Category> categoryDAO;
        private ICategoryAwareDAO<Provider> providerDAO;

        internal IList<Category> GetCategoriesByProvider(long idProvider)
        {
            Provider provider = new Provider();
            provider.Id = idProvider;
            return providerDAO.GetCategoriesByElement(provider);
        }

        internal IList<Category> GetAllCategories()
        {
           return categoryDAO.FindAll();
        }

        internal Category GetCategory(long id)
        {
            return categoryDAO.FindById(id);
        }

        internal IList<Category> GetCategoriesNotInProvider(long idProvider)
        {
            IList<Category> allCategories = this.GetAllCategories();
            IList<Category> categorities = this.GetCategoriesByProvider(idProvider);
       
            foreach (Category c in categorities)
            {
                if (allCategories.Contains(c))
                    allCategories.Remove(c);
            }
            return allCategories;
          
        }
    }
}
