

using System;
namespace ArmandoShop.Model
{
    [Serializable]
    public class Product
    {
        private long id;
        private string name;
        private int stock;
        private string description;
        private decimal price;
        private Category category;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public Category Category
        {
            get { return category; }
            set { category = value; }
        }

        public override string ToString()
        {
            return "Product [Id="
                + Id + " ,Name=" + Name + " ,Price=" + Price + " ,Stock="
                + Stock + " ,Description ="
                + Description + " ,category = "
                + Category + "] \n";
        }

        public override bool Equals(object obj)
        {
            Product other = (Product)obj;
            return other.Id == Id;
        }

    }
}
