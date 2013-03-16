using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ArmandoShop.Model;

namespace ArmandoShop.Services.Contracts
{
    [ServiceContract(Namespace = "http://ArmandoShop.OrdersService")]
    public interface IOrdersService
    {
        [OperationContract]
        IList<Order> ListOrders();


        [OperationContract]
        IList<Product> GetProductsByOrder(long id);

        [OperationContract]
        Order GetOrder(long id);

        [OperationContract]
        long NewOrder(Order order);

        [OperationContract]
        void ModifyOrder(Order order);

        [OperationContract]
        void DeleteOrder(long ikd);
    }
}
