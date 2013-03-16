using ArmandoShop.Model;
using System.Data.Common;

namespace ArmandoShop.DataAccess.Mapping
{
    internal class OrderMapper:IRowMapper<Order>
    {
        public Order MapRow(DbDataReader reader)
        {
            /*Be care full, the order of extractionmust 
           * be the same of sql proyection */

            Order order = new Order();
            order.Id = reader.GetInt64(0);
            order.DateOfBuy = reader.GetDateTime(1);
            order.DateOfDeliver = reader.GetDateTime(2);
            order.Delivered = reader.GetBoolean(3);
            order.Customer = this.GetCustomer(reader);
            return order;
        }

        private Customer GetCustomer(DbDataReader reader)
        {
            Customer customer = new Customer();
           
            customer.Id = reader.GetInt64(4);
            customer.Name = reader.GetString(5);
            customer.Surname = reader.GetString(6);
            customer.Address = reader.GetString(7);
            customer.Phone = reader.GetString(8);

            return customer;
        }
    }
}
