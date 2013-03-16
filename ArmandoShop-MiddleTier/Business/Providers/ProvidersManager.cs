using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;
using ArmandoShop.DataAccess;

namespace ArmandoShop.Business.Providers
{
    //It is internal by default
    internal class ProvidersManager
    {
        private IDAO<Provider> providerDAO;
        /*Members by default are private..*/
       
        internal void ModifyProvider(Provider provider) {
            providerDAO.Update(provider);
        }

        internal void DeleteProvider(long id)
        {
            providerDAO.Remove(id);
        }

        internal long CreateProvider(Provider provider)
        {
            return providerDAO.Create(provider);
        }
    }
}
