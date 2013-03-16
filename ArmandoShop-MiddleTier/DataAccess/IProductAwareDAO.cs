using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;

namespace ArmandoShop.DataAccess
{
    public interface IProductAwareDAO<T> : IDAO<T>
    {
        IList<Product> GetProductsByElement(T element);

        void AddProductToElement(Product product, T element);

        void RemoveProductOfElement(Product product, T element);
    }
}


