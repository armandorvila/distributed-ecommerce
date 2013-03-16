using System;
using System.Collections.Generic;
using ArmandoShop.ProvidersClient.Model.Services;
using System.Text;

namespace ArmandoShop.ProvidersClient.Model
{
    /// <summary>
    /// Class which encapsulate Business Functionality, offer Business methods 
    /// by  delegating to real Business tier.
    /// </summary>
    internal class ProductsBusinessDelegate
    {
       
        internal IList<Product> GetProductsByCategory(Category category)
        {
            using (ProductsServiceClient client = new ProductsServiceClient())
            {
                return client.
                    GetProductsByCategory(category.id);
            }
        }

        internal void ModifyProduct(Product product)
        {
            using (ProductsServiceClient client = new ProductsServiceClient())
            {
                client.ModifyProduct(product);
            }
        }
    }
}
