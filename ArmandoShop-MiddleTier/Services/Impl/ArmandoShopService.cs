using System.Collections.Generic;
using ArmandoShop.Business;
using ArmandoShop.Model;
using ArmandoShop.Services.Contracts;

namespace ArmandoShop.Services.Impl
{
    /// <summary>
    /// Operations are implementeds in separated files..
    /// </summary>
    public partial class ArmandoShopService :IProductsService, 
        IProvidersService, IUsersService, ICategoryService , 
        IOrdersService,ICustomersService,IContractsService
    {

        #region Agregated fields

        private IProvidersFacade  providersFacade;
        private IProductsFacade   productsFacade;
        private ICategoriesFacade categoryFacade;
        private IUsersFacade      usersFacade;
        private IOrdersFacade     ordersFacade;
        private ICustomersFacade customersFacade;
        private IContractsFacade contractsFacade;
  

        #endregion

        /*There is not operation in this file..*/
        
        #region Properties

        public IProductsFacade ProductsFacade
        {
            get { return productsFacade; }
            set { productsFacade = value; }
        }

        public IProvidersFacade ProvidersFacade
        {
            get { return providersFacade; }
            set { providersFacade = value; }
        }

        public ICategoriesFacade CategoriesFacade
        {
            get { return categoryFacade; }
            set { categoryFacade = value; }
        }

        public IUsersFacade UsersFacade
        {
            get { return usersFacade; }
            set { usersFacade = value; }
        }

        public IOrdersFacade OrdersFacade
        {
            get { return ordersFacade; }
            set { ordersFacade = value; }
        }

        public ICustomersFacade CustomersFacade
        {
            get { return customersFacade; }
            set { customersFacade = value; }
        }

        public IContractsFacade ContractsFacade
        {
            get { return this.contractsFacade; }
            set { this.contractsFacade = value; }
        }

        #endregion

    }
}
