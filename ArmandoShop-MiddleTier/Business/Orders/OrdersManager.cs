using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.DataAccess;
using ArmandoShop.Model;

namespace ArmandoShop.Business.Orders
{
    internal class OrdersManager
    {
        private IProductAwareDAO<Order> orderDAO;

        internal long CreateOrder(Model.Order order)
        {
            order.Id = orderDAO.Create(order);
            foreach (Product product in order.Products)
                orderDAO.AddProductToElement(product, order);
            return order.Id;
        }

        internal void DeleteOrder(long id)
        {
            orderDAO.Remove(id);
        }

        internal void ModifyOrder(Order order)
        {
            orderDAO.Update(order);
        }
    }
}
