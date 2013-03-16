using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.CompilerServices;
using ArmandoShop.WebApplication.Models.Model;
using ArmandoShop.WebApplication.Models.Services;

namespace ArmandoShop.WebApplication.Models.Application
{
    public class Broker
    {
        private static Broker INSTANCE = new Broker();
        private DelegateOrdersService service;
        private DelegateProductsService productsService;

        private Broker()
        {
            service = new DelegateOrdersService();
            productsService = new DelegateProductsService();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static Broker GetBroker()
        {
            return INSTANCE;
        }

        public long ProcessCart(Cart Cart, User user)
        {

            Order order = this.MapToOrder(Cart, user);
            this.UpdateProducts(order);
            return service.NewOrder(order);
        }

        public void GiveControlToBank(object passarela)
        {
            /*I am human, the time is finite...!!!*/
        }

        private void UpdateProducts(Order order)
        {
            foreach (Product product in order.products)
            {
                product.stock = product.stock - order.amounts[product.id];
                productsService.ModifyProduct(product);
            }
        }

        private Order MapToOrder(Cart Cart, User user)
        {
            Order order = new Order();
            Customer customer = new DelegateCustomersService()
               .GetCustomerByUser(user);
            order.products = new List<Product>();
            order.amounts = new Dictionary<long, int>();
            order.customer = customer;
            order.dateOfBuy = DateTime.Now;
            order.delivered = false;
            order.dateOfDeliver = DateTime.Now;

            foreach (Product product in Cart.Products)
            {
                /*Debido a algo que se me escapa el mvc me pierde la categoria del producto, luego tengo que ir a por el.*/
                order.products.Add(productsService.GetProduct(product.id));
                order.amounts.Add(product.id, Cart.Amounts[product.id]);
            }

            return order;
        }

    }
}