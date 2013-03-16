using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;

namespace ArmandoShop.Business.Products
{
    class ProductsFacadeImpl:IProductsFacade
    {

        #region Fields

        private ProductsSupplier supplier;
        private ProductsManager manager;
  
        #endregion

        #region Methods
        public Product GetProduct(long id)
        {
            return this.supplier.GetProduct(id);
        }

        public IList<Product> ListProducts()
        {
            return supplier.GetAllProducts();
        }

        public long NewProduct(Product product)
        {
           return this.manager.CreateProduct(product);
        }

        public void DeleteProduct(long id)
        {
            this.manager.DeleteProduct(id);
        }

        public void ModifyProduct(Product product)
        {
            this.manager.UpdateProduct(product);
        }

        public IList<Product> GetProductsByCategory(long idCategory)
        {
           return supplier.GetProductsByCategory(idCategory);
        }

        #endregion


    
    }
}
