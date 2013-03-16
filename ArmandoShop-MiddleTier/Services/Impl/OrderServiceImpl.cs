using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;

namespace ArmandoShop.Services.Impl
{
   partial class ArmandoShopService
    {


        public long NewOrder(Order order)
        {
            return this.ordersFacade.CreateOrder(order);
        }


     
        public IList<Product> GetProductsByOrder(long id)
        {
            return this.ordersFacade.GetProductsByOrder(id);
        }


        public void ModifyOrder(Order order)
        {
            this.ordersFacade.ModifyOrder(order);
        }

        public void DeleteOrder(long id)
        {
            this.ordersFacade.DeleteOrder(id);
        }

        public IList<Order> ListOrders()
        {
            return ordersFacade.ListOrders();
        }

        public Order GetOrder(long id)
        {
            return ordersFacade.GetOrder(id);
        }
    }
}
