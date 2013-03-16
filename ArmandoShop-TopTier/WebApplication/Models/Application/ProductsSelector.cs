using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArmandoShop.WebApplication.Models.Services;

namespace ArmandoShop.WebApplication.Models.Application
{
    public class ProductsSelector
    {
        private DelegateProductsService productsService;
        private DelegateOrdersService ordersService;

        public ProductsSelector()
        {
            this.productsService = new DelegateProductsService();
            this.ordersService = new DelegateOrdersService();
        }

        public List<Product> GetMostWamtedProducts(int num)
        {
            List<Product> products = new List<Product>();
            List<Product> all = productsService.ListProducts();
            long[] ids = new long[num];
            while (num > 0)
            {
                Product prod = this.GetMostWantedProduct(all);
                if (!ids.Contains(prod.id))
                {
                    products.Add(prod);
                    ids[products.Count-1] = prod.id;          
                }
                num--;
            }
            return products;
        }

        /// <summary>
        /// To Get a most wanted product with a goood performance is necesary  delegate it to 
        /// the lower tier, creating a service of statics and improving the statics performance too....
        /// </summary>
        public Product GetMostWantedProduct(List<Product> all)
        {
            Product mostWanted = null;

            
            int pos = new Random(10).Next(0, all.Count);
            if (all.Count > 0)
                mostWanted = all[pos];
            return mostWanted;
        }

    }
}