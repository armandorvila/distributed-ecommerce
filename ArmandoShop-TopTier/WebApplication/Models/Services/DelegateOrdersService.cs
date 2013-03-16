using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArmandoShop.WebApplication.Models.Services
{
    public class DelegateOrdersService
    {

        public long NewOrder(Order order)
        {
            using (OrdersServiceClient client = new OrdersServiceClient())
            {
                return client.NewOrder(order);
            }
        }

        public List<Order> ListOrders()
        {
            using (OrdersServiceClient client = new OrdersServiceClient())
            {
                return client.ListOrders();
            }
        }

        public List<Product> GetProductsOfOrders(long idOrder)
        {
            using (OrdersServiceClient client = new OrdersServiceClient())
            {
                return client.GetProductsByOrder(idOrder); 
            }
        }

    }
}