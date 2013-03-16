using System.Collections.Generic;
using ArmandoShop.Model;

namespace ArmandoShop.Business
{
    public interface IProvidersFacade
    {
        Provider GetProvider(long id);

        Provider GetProvider(User user);

        IList<Provider> ListProviders();

        IList<Provider> GetProvidersByCategory(long idCategory);

        long NewProvider(Provider provider);

        void ModifyProvider(Provider provider);

        void DeleteProvider(long id);
    }
}
