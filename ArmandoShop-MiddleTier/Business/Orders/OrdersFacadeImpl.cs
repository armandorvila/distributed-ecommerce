using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Business;
using ArmandoShop.Model;

namespace ArmandoShop.Business.Orders
{
    public class OrdersFacadeImpl:IOrdersFacade
    {
        private OrdersManager manager;
        private OrdersSupplier supplier;

        public IList<Order> ListOrders()
        {
            return supplier.GetAllOrders();
        }

        public Order GetOrder(long id)
        {
            return supplier.GetOrder(id);
        }


        public long CreateOrder(Order order)
        {
            return manager.CreateOrder(order);
        }

        public void DeleteOrder(long id)
        {
            manager.DeleteOrder(id);
        }


        public IList<Product> GetProductsByOrder(long idOrder)
        {
            return supplier.GetProductsByOrder(idOrder);
        }


        public void ModifyOrder(Order order)
        {
            this.manager.ModifyOrder(order);
        }
    }
}
