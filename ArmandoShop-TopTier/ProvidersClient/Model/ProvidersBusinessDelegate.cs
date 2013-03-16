using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.ProvidersClient.Model.Services;


namespace ArmandoShop.ProvidersClient.Model
{
    class ProvidersBusinessDelegate
    {

        public Provider GetProvider(long id)
        {
            using (ProvidersServiceClient client = new ProvidersServiceClient())
            {
                return client.GetProvider(id);
            }
        }

        public Provider GetProviderByUser(User user)
        {
            using (ProvidersServiceClient client = new ProvidersServiceClient())
            {
                return client.GetProviderByUser(user);
            }
        }

        public void ModifyProvider(Provider provider)
        {
            using (ProvidersServiceClient client = new ProvidersServiceClient())
            {
                client.ModifyProvider(provider);
            }
        }

    }
}
