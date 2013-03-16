using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmandoShop.Model
{
    [Serializable]
    public class Contract
    {
        private long id;
        private Provider provider;
        private Product product;
        private int stock;
        private bool charged;
        private DateTime date;

        public bool Charged
        {
            get { return charged; }
            set { charged = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public long Id
        {
            get { return id; }
            set { id = value; }
        }


        public Provider Provider
        {
            get { return provider; }
            set { provider = value; }
        }

        public Product Product
        {
            get { return product; }
            set { product = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }
    }
}
