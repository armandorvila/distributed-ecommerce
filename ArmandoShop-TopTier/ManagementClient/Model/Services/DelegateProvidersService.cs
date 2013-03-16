using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmandoShop.ManagementClient.Model.Services
{
    class DelegateProvidersService
    {


        public List<Provider> ListProviders()
        {
            List<Provider> providers = new List<Provider>();
            using (ProvidersServiceClient client = new ProvidersServiceClient())
            {
                providers = client.ListProviders();
            }

            return providers;
        }


        public long NewProvider(Provider provider)
        {
            long id = -1;
            using (ProvidersServiceClient client = new ProvidersServiceClient())
            {
                id = client.NewProvider(provider);
            }
            return id;
        }

        public void ModifyProvider(Provider provider)
        {
            using (ProvidersServiceClient client = new ProvidersServiceClient())
            {
                client.ModifyProvider(provider);
            }
        }

        public void DeleteProvider(long id)
        {
            using (ProvidersServiceClient client = new ProvidersServiceClient())
            {
                client.DeleteProvider(id);
            }
        }
    }
}
