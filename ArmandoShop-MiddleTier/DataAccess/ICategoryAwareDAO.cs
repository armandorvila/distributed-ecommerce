using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;

namespace ArmandoShop.DataAccess
{
    public interface ICategoryAwareDAO <T> : IDAO<T>
    {
        IList<Category> GetCategoriesByElement(T element);

        void AddCatagorityToElement(Category category, T element);

        void RemoveCategoryOfElement(Category category, T element);

    }
}
