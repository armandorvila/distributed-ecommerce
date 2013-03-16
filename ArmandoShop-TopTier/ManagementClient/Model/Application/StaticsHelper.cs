using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.ManagementClient.Model.Services;

namespace ArmandoShop.ManagementClient.Model.Application
{
    internal class StaticsHelper
    {
        internal long GetNumProviders()
        {
            return new DelegateProvidersService().ListProviders().Count;
        }

        internal long GetNumProducts()
        {
            return new DelegateProductsService().ListProducts().Count;
        }

        internal long GetNumCategories()
        {
            return new DelegateCategoryService().ListCategories().Count;
        }

        internal long GetNumOrders()
        {
            return -1;
        }

        internal long GetNumContracts()
        {
            return -1;
        }

        internal long GetNumCustomers()
        {
            return new DelegateCustomersService().ListCustomers().Count;
        }

        internal string GetMostValueProvider()
        {
            string name = "No Calculated";

            return name;
        }

        internal string GetMostValueCategory()
        {
            string name = "";
            List<Product> products = new List<Product>();
            using (ProductsServiceClient client = new ProductsServiceClient()){
                 products = client.ListProducts(); 
            }
            name = this.ExtractMoreExistentCategory(products);
            return name;
        }

        private string ExtractMoreExistentCategory(List<Product> products)
        {
            string mvName = "";
            int  mvOccurrences = 0;

            foreach (Product product in products)
            {
                long id = product.category.id;
                int count = 0;
                foreach (Product inproduct in products)
                {
                    if (inproduct.category.id == id)
                    {
                        count++;
                    }
                }

                if (count > mvOccurrences)
                {
                    mvOccurrences = count;
                    mvName = product.category.name;
                }
            }

            return mvName;
        }

        internal string GetMostValueProduct()
        {
            string name = "No Calculated";

            return name;
        }
    }
}
