using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace ArmandoShop.Model
{
    [Serializable]
    public class Category : IEquatable<Category>
    {
        public Category()
        {
            providers = new List<Provider>();
            products = new List<Product>();
        }

        private long id;
        private string name;
        private string description;
        private IList<Provider> providers;
        private IList<Product> products;

        public long Id 
        { 
            get { return id; } 
            set { id = value; }
        }

        public string Name
        { get { return name; } 
            set { name = value; } 
        }

        public string Description 
        { 
            get { return description; } 
            set { description = value; } 
        }

        public IList<Provider> Providers
        {
            get { return new ReadOnlyCollection<Provider>(providers); }
        }

        public IList<Product> Products
        {
            get { return new ReadOnlyCollection<Product>(products); }
        }

        public void addProvider(Provider provider)
        {
            this.providers.Add(provider);
        }

        public void addProvider(Product product)
        {
            this.products.Add(product);
        }

        public override string ToString()
        {
            return "category [ID=" + Id + ",Name =" + Name
                + " ,Description =" + Description + "]";
        }

        public bool Equals(Category other)
        {
            return other.Id == Id;
        }
    }
}
