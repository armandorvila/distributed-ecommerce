using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;
using ArmandoShop.DataAccess;

namespace ArmandoShop.Business.Products
{
    class ProductsManager
    {
        private IDAO<Product> productDAO;


        internal long CreateProduct(Product product)
        {
            /*If the category of product dosent Exist => ERROR.*/
            return productDAO.Create(product);
        }

        internal void UpdateProduct(Product product)
        {
            /*If the category of product dosent Exist => ERROR.*/
            productDAO.Update(product);
        }

        internal void DeleteProduct(long id)
        {
            this.productDAO.Remove(id);
        }

    }
}
