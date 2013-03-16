using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArmandoShop.WebApplication.Models.Services
{
    public class DelegateProductsService
    {
        public Product GetProduct(long id)
        {
            Product product = null;
            using (ProductsServiceClient client = new ProductsServiceClient())
            {
                product = client.GetProduct(id);
            }
            return product;
        }

        public List<Product> ListProducts()
        {
            List<Product> products = new List<Product>();
            using (ProductsServiceClient client = new ProductsServiceClient())
            {
                products = client.ListProducts();
            }
            return this.FilterNoStockProducts(products);
        }

        public List<Product> GetProductsByCategory(long idCategory)
        {
            List<Product> products = new List<Product>();
            using (ProductsServiceClient client = new ProductsServiceClient())
            {
                products = client.GetProductsByCategory(idCategory);
            }
            return this.FilterNoStockProducts(products);
        }

        private List<Product> FilterNoStockProducts(List<Product> superSet)
        {
            List<Product> toRemove = new List<Product>();
            foreach (Product product in superSet)
            {
                if (product.stock == 0)
                {
                    toRemove.Add(product);
                }
            }
            foreach (Product product in toRemove)
                superSet.Remove(product);
            return superSet;

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