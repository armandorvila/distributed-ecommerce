using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
namespace ArmandoShop.Model
{
    [Serializable]
    public class Provider
    {

        public Provider()
        {
            this.categories = new List<Category>();
        }

        private IList<Category> categories;

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

        public IList<Category> Categories {
            get { return new ReadOnlyCollection<Category>(categories); }
        }

        public void AddCategory(Category category)
        {
            this.categories.Add(category);
        }

        public override string ToString()
        {
            return "Provider [ Id = " + Id +" ,Name = "
                + Name + " ,Mail = " + Mail  + "]";
        }

        public override bool Equals(object obj)
        {
            Provider other = (Provider)obj;
            return other.Id == Id;
        }

    }
}
