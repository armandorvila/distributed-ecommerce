using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArmandoShop.WebApplication.Models.Services;
using System.Collections.ObjectModel;

namespace ArmandoShop.WebApplication.Models.Model
{
    public class Cart
    {

        private Dictionary<long, Product> products;
        private Dictionary<long, int> amounts;

        public Cart()
        {
            this.products = new Dictionary<long, Product>();
            this.amounts = new Dictionary<long, int>();
        }

        public void AddProduct(Product product)
        {
            if (this.products.ContainsKey(product.id))
            {
                this.amounts[product.id]++;

            }
            else
            {
                this.products.Add(product.id, product);
                this.amounts.Add(product.id, 1);
            }
        }

        public void DecrementAmount(long idProduct)
        {
            if (products.ContainsKey(idProduct)
                && amounts[idProduct] > 0)
            {
                amounts[idProduct]--;
                if (amounts[idProduct] == 0)
                    this.RemoveProduct(idProduct);
            }
        }

        public Product GetProduct(long id)
        {
            return products[id];
        }

        public void RemoveProduct(long id)
        {
            if (products.ContainsKey(id))
            {
                products.Remove(id);
                amounts.Remove(id);
            }
        }


        public IList<Product> Products
        {
            get
            {
                return new
                    ReadOnlyCollection<Product>(new List<Product>(products.Values));
            }
        }

        public IDictionary<long, int> Amounts
        {
            get { return amounts; }
        }
    }
}