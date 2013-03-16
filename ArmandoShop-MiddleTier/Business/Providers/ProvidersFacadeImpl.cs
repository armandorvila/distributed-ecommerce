using System.Collections.Generic;
using ArmandoShop.Model;

namespace ArmandoShop.Business.Providers
{
    class ProvidersFacadeImpl:IProvidersFacade
    {

        private ProvidersSupplier supplier;
        private ProvidersManager manager;

        public IList<Provider> ListProviders()
        {
            return supplier.GetAllProviders();
        }

        public Provider GetProvider(long id)
        {
           return  supplier.GetProvider(id);
        }

        public IList<Provider> GetProvidersByCategory(long idCategory)
        {
            return supplier.GetProvidersByCategory(idCategory);
        }

        public long NewProvider(Provider provider)
        {
            return manager.CreateProvider(provider);
        }

        public void ModifyProvider(Provider provider)
        {
            manager.ModifyProvider(provider);
        }

        public void DeleteProvider(long id)
        {
            manager.DeleteProvider(id);
        }


        public Provider GetProvider(User user)
        {
            return supplier.GetProvider(user);
        }
    }
}
