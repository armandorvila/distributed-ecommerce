using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;

namespace ArmandoShop.DataAccess
{
    public interface IProviderAwareDAO <T> : IDAO<T>
    {
       IList<Provider> GetProvidersByElement(T element);

       void AddProviderToElement(Provider provider, T element);

       void RemoveProviderOfElement(Provider provider, T element);

    }
}
