using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmandoShop.ManagementClient.Model.Services
{
    public class DelegateProductsService : IProductsService
    {

        public Product GetProduct(long id)
        {
            Product product = null;

            return product;
        }

        public List<Product> ListProducts()
        {
            List<Product> products = new List<Product>();
            using (ProductsServiceClient client = new ProductsServiceClient())
            {
                products = client.ListProducts();
            }
            return products;
        }

        public List<Product> GetProductsByCategory(long idCategory)
        {
            List<Product> products = new List<Product>();
            using (ProductsServiceClient client = new ProductsServiceClient())
            {
                products = client.GetProductsByCategory(idCategory);
            }
            return products;
        }

        public long NewProduct(Product product)
        {
            long id = -1;
            using (ProductsServiceClient client = new ProductsServiceClient())
            {
                id = client.NewProduct(product);
            }
            return id;
        }

        public void ModifyProduct(Product product)
        {
            using (ProductsServiceClient client = new ProductsServiceClient())
            {
                client.ModifyProduct(product);
            }
        }

        public void DeleteProduct(long id)
        {
            using (ProductsServiceClient client = new ProductsServiceClient())
            {
                client.DeleteProduct(id);
            }
        }
    }
}
