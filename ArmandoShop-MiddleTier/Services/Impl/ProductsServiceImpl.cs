using System.Collections.Generic;
using ArmandoShop.Business;
using ArmandoShop.Model;
using ArmandoShop.Services.Contracts;

namespace ArmandoShop.Services.Impl
{
    /// <summary>
    /// Here is the implementation of ProductsServiceContract
    /// </summary>
    public partial class ArmandoShopService
    {
       
        public IList<Product> ListProducts()
        {
            return productsFacade.ListProducts();
        }

        public Product GetProduct(long id)
        {
            return productsFacade.GetProduct(id);
        }

        public IList<Product> GetProductsByCategory(long idCategory)
        {
            return productsFacade.GetProductsByCategory(idCategory);
        }


        public long NewProduct(Product product)
        {
            return productsFacade.NewProduct(product);
        }

        public void ModifyProduct(Product product)
        {
            productsFacade.ModifyProduct(product);
        }

        public void DeleteProduct(long id)
        {
            productsFacade.DeleteProduct(id);
        }
    }

}