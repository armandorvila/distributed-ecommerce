using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Context;
using Spring.Context.Support;
using ArmandoShop.Business.Products;


namespace ArmandoShop.Business
{
    /// <summary>
    /// Only for tests, the 
    /// business objects are going to injecteds to service layer.
    /// </summary>
    public class BusinessFactory
    {
        public static BusinessFactory FACTORY = new BusinessFactory();

        private BusinessFactory() { }

        public IProductsFacade GetProductsFacade () {
           
            IApplicationContext context = ContextRegistry.GetContext();
            return (IProductsFacade)context.GetObject("productsFacade");
           
        }

        public IProvidersFacade GetProvidersFacade()
        {

            IApplicationContext context = ContextRegistry.GetContext();
            return (IProvidersFacade)context.GetObject("providersFacade");

        }
    }
}
