using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.ProvidersClient.Model.Services;

namespace ArmandoShop.ProvidersClient.Model
{
    internal class CategoryBusinessDelegate
    {

        internal IList<Category> GetCategoriesByProvider(Provider provider)
        {
            using (CategoryServiceClient client = new CategoryServiceClient())
            {
                return client.
                      GetCategoriesByProvider(provider.id);
            }
        }

        internal IList<Category> GetCategoriesOutProvider(Provider provider)
        { 
            using (CategoryServiceClient client = new CategoryServiceClient())
            {
            return client.GetCategoriesNotInProvider(provider.id);
            }
        }

        internal void AddCategory(Provider provider, Category category)
        {
            using (CategoryServiceClient client = new CategoryServiceClient())
            {
                client.
                    AddProviderToCategory(provider.id, category.id);
            }
        }

        internal void RemoveCategory(Provider provider, Category category)
        {
            using (CategoryServiceClient client = new CategoryServiceClient())
            {
                client.
                   RemoveProviderOfCategory(provider.id, category.id);
            }
        }
    }
}
