using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmandoShop.Model
{
    [Serializable]
    public class User
    {
        private long id;

        private string username;

        private string password;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public override bool Equals(object obj)
        {
            User other = (User)obj;
            return other.password == password;
        }
    }
}
