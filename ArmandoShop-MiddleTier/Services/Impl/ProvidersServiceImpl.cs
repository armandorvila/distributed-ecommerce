using System.Collections.Generic;
using ArmandoShop.Business;
using ArmandoShop.Model;
using ArmandoShop.Services.Contracts;

namespace ArmandoShop.Services.Impl
{
    /// <summary>
    /// Partial class wich implements IProvidersService Contract
    /// </summary>
    public partial class ArmandoShopService
    {
        public IList<Provider> ListProviders()
        {
            return providersFacade.ListProviders();
        }

        public Provider GetProviderByUser(User user)
        {
            return providersFacade.GetProvider(user);
        }

        public Provider GetProvider(long id)
        {
            return providersFacade.GetProvider(id);
        }

        public IList<Provider> GetProvidersByCategory(long idCategory)
        {
           return providersFacade.GetProvidersByCategory(idCategory);
        }

        public long NewProvider(Provider provider)
        {
            return providersFacade.NewProvider(provider);
        }

        public void ModifyProvider(Provider provider)
        {
            providersFacade.ModifyProvider(provider);
        }

        public void DeleteProvider(long id)
        {
            providersFacade.DeleteProvider(id);
        }
    }

}