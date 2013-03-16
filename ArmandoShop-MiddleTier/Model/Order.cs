using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace ArmandoShop.Model
{
    [Serializable]
    public class Order
    {

        public Order()
        {
            this.products = new List<Product>();
            this.amounts = new Dictionary<long,int>();
        }

        private IList<Product> products;
        private IDictionary<long,int> amounts;
        private long id;
        private DateTime dateOfBuy;
        private DateTime dateOfDeliver;
        private Boolean delivered;
        private Customer customer;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public IDictionary<long, int> Amounts
        {
            get { return amounts; }
            set { amounts = value; }
        }

        public DateTime DateOfBuy
        {
            get { return dateOfBuy; }
            set { dateOfBuy = value; }
        }
        public DateTime DateOfDeliver
        {
            get { return dateOfDeliver; }
            set { dateOfDeliver = value; }
        }
        public Boolean Delivered
        {
            get { return delivered; }
            set { delivered = value; }
        }
        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public IList<Product> Products
        {
            get { return new ReadOnlyCollection<Product>(products); }
        }

        public void addProduct(Product product)
        {
            this.products.Add(product);
        }

        public override string ToString()
        {
            return "Order [ ID= " + Id + " ,DateOfBuy = "
                + DateOfBuy + " ,DateOfDeliver= " + DateOfDeliver + "Delivered = "
                + Delivered + "]";
        }

      
    }
}
