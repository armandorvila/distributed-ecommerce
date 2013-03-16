using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ArmandoShop.WebApplication.Models.Model
{
    public class StaticsModel
    {
       
        [DisplayName("Number of delivered Orders:")]
        public long OrdersNumber { get; set; }

        [DisplayName("Number of finished contracts:")]
        public long ContractsNumber { get; set; }

        [DisplayName("Number of Providers:")]
        public long ProviedersNumber{ get; set; }

        
        [DisplayName("Number of Customers:")]
        public long CustomersNumber { get; set; }

        [DisplayName("Number of Products:")]
        public long ProductsNumber { get; set; }

        [DisplayName("Number of Categories:")]
        public long CategoriesNumber { get; set; }
    }
}