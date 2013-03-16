using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;
using ArmandoShop.DataAccess;

namespace ArmandoShop.Business.Orders
{
    internal class OrdersSupplier
    {

        private IProductAwareDAO<Order> orderDAO;

        internal IList<Model.Order> GetAllOrders()
        {   
            return orderDAO.FindAll();
        }

        internal IList<Product> GetProductsByOrder(long idOrder)
        {
            Order order = new Order();
            order.Id = idOrder;
            return orderDAO.GetProductsByElement(order);
        }
        
        internal Order GetOrder(long id)
        {
            return orderDAO.FindById(id);
        }
    }
}
