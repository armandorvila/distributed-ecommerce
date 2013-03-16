using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;

namespace ArmandoShop.Business
{
    public interface ICategoriesFacade
    {      
        IList<Category> ListCategories();
        
        IList<Category> GetCategoriesByProvider(long idProvider);

        IList<Category> GetCategoriesNotInProvider(long idProvider);

        void AddProviderToCategory(long idProvider, long idcategory);

        void RemoveProviderOfCategory(long idProvider, long idcategory);

        Category GetCategory(long id);
       
        long NewCategory(Category category);

        void DeleteCategory(long id);

        void ModifyCategory(Category category);
    }
}
