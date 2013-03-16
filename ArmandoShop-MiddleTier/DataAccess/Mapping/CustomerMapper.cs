using ArmandoShop.Model;
using System.Data.Common;

namespace ArmandoShop.DataAccess.Mapping
{
    internal class CustomerMapper : IRowMapper<Customer>
    {
        public Customer MapRow(DbDataReader reader)
        {
            Customer customer = new Customer();
            /*Be care full, the order of extractionmust 
            * be the same of sql proyection */
            customer.Id = reader.GetInt64(0);
            customer.Name = reader.GetString(1);
            customer.Surname = reader.GetString(2);
            customer.Address = reader.GetString(3);
            customer.Phone = reader.GetString(4);
            customer.Mail = reader.GetString(5);

            customer.User = this.GetUser(reader);
            
            return customer;
        }

        private User GetUser(DbDataReader reader)
        {
            User user = new User();
            user.Id = reader.GetInt64(6);
            user.Username = reader.GetString(7);
            user.Password = reader.GetString(8);
            return user;
        }
    }
}
