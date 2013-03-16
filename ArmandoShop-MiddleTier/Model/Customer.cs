using System;

namespace ArmandoShop.Model
{
    [Serializable]
    public class Customer
    {
        private long id;
        private string name;
        private string surname;
        private string mail;
        private string phone;
        private string address;
        private User user;

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
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public override string ToString()
        {
            return "Product [Id="
                + Id + " ,Name=" + Name + " ,surname=" + Surname + " ,Address=" + Address + " ,Phone ="
                + Phone + "] \n";
        }

        public override bool Equals(object obj)
        {
            Customer other = (Customer)obj;
            return other.Id == Id;
        }
    }
}
