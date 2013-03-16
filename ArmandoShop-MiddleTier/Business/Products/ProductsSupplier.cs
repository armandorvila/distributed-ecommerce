using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;
using ArmandoShop.DataAccess;

namespace ArmandoShop.Business.Products
{
    class ProductsSupplier
    {
        private IDAO<Product> productDAO;
        private IProductAwareDAO<Category> categoryProductAwareDAO;

        internal IList<Product> GetAllProducts()
        {
            return productDAO.FindAll();
        }

        internal Product GetProduct(long id)
        {
            return this.productDAO.FindById(id);
        }

        internal IList<Product> GetProductsByCategory(long idCategory)
        {
            Category category = new Category();
            category.Id = idCategory;
            return categoryProductAwareDAO.GetProductsByElement(category);
        }

    }
}
