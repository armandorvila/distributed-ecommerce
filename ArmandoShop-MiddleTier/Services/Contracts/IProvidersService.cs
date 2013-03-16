using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ArmandoShop.Model;

namespace ArmandoShop.Services.Contracts
{
    [ServiceContract (Namespace="http://ArmandoShop.ProvidersService")]
    public interface IProvidersService
    {
        [OperationContract]
        Provider GetProvider(long id);

        [OperationContract]
        Provider GetProviderByUser(User user);

        [OperationContract]
        IList<Provider> ListProviders();

         [OperationContract]
        IList<Provider> GetProvidersByCategory(long idCategory);

        [OperationContract]
        long NewProvider(Provider provider);

        [OperationContract]
        void ModifyProvider(Provider provider);

        [OperationContract]
        void DeleteProvider(long id);
    }
}
