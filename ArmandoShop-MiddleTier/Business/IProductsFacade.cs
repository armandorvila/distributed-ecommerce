using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;

namespace ArmandoShop.Business
{
    public interface IProductsFacade
    {
        Product GetProduct(long id);
        
        IList<Product> ListProducts();

        IList<Product> GetProductsByCategory(long idCategory);

        long NewProduct(Product product);

        void DeleteProduct(long id);

        void ModifyProduct(Product product);
    }
}
