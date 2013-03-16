using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.DataAccess;
using ArmandoShop.Model;

namespace ArmandoShop.Business.Providers
{
    internal class ProvidersSupplier
    {

        private IDAO<Provider> providerDAO;
        private IProviderAwareDAO<Category> categoryDAO;
        private IUserAwareDAO<Provider> providerUserAwareDAO;

        internal Provider GetProvider(long id)
        {
            return providerDAO.FindById(id);
        }

        internal IList<Provider> GetAllProviders()
        {
            return providerDAO.FindAll();
        }

        internal IList<Provider> GetProvidersByCategory(long idCategory)
        {
            Category category = new Category();
            category.Id = idCategory;
            return categoryDAO.GetProvidersByElement(category);
        }

        internal Provider GetProvider(User user)
        {
            return this.providerUserAwareDAO.GetElementByUser(user);
        }
    }
}
