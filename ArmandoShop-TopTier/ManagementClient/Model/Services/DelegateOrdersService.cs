using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmandoShop.ManagementClient.Model.Services
{
    class DelegateOrdersService:IOrdersService
    {
        public List<Order> ListOrders()
        {
            using (OrdersServiceClient client = new OrdersServiceClient())
            {
                return client.ListOrders();
            }
        }

        public Order GetOrder(long id)
        {
            using (OrdersServiceClient client = new OrdersServiceClient())
            {
                return client.GetOrder(1);
            }
        }

        public long NewOrder(Order order)
        {
            using (OrdersServiceClient client = new OrdersServiceClient())
            {
                return client.NewOrder(order);
            }
        }

        public void DeleteOrder(long id)
        {
            using (OrdersServiceClient client = new OrdersServiceClient())
            {
                client.DeleteOrder(id);
            }
        }

        public void ModifyOrder(Order order)
        {
            using (OrdersServiceClient client = new OrdersServiceClient())
            {
                client.ModifyOrder(order);
            }
        }
    }
}
