using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;

namespace ArmandoShop.Business
{
    public interface IOrdersFacade
    {
        IList<Order> ListOrders();

        Order GetOrder(long id);

        long CreateOrder(Order order);

        void DeleteOrder(long id);

        IList<Product> GetProductsByOrder(long idOrder);


        void ModifyOrder(Order order);
    }
}
