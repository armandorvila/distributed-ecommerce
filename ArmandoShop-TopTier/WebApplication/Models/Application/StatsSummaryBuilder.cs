using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArmandoShop.WebApplication.Models.Model;
using ArmandoShop.WebApplication.Models.Services;

namespace ArmandoShop.WebApplication.Models.Application
{
    public class StatsSummaryBuilder
    {
        public StaticsModel BuildStaticsModel()
        {
            StaticsModel statics = new StaticsModel();
            statics.CategoriesNumber = this.getNuberOfCategories();
            statics.ContractsNumber = this.GetNumberOfContracts();
            statics.CustomersNumber = this.GetNumberOfCustomers();
            statics.OrdersNumber = this.GetNumberOfProducts();
            statics.ProductsNumber = this.GetNumberOfProducts();
            statics.ProviedersNumber = this.GetNumberOfProviders();
            return statics;
        }

        private long GetNumberOfProviders()
        {
            return 10;
        }

        private long GetNumberOfProducts()
        {
            return new DelegateProductsService().ListProducts().Count;
        }

        private long getNuberOfCategories()
        {
            return new DelegateCategoriesService().ListCategories().Count;
        }

        private long GetNumberOfCustomers()
        {
            return 10;
        }

        private long GetNumberOfOrders()
        {
            return new DelegateOrdersService().ListOrders().Count;
        }

        private long GetNumberOfContracts()
        {
            return new DelegateContractsService().ListContracts().Count;
        }
    }
}