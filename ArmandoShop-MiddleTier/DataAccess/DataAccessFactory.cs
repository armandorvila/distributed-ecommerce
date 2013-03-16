using ArmandoShop.Model;
using ArmandoShop.DataAccess.Util;
using ArmandoShop.DataAccess.Sql;
using ArmandoShop.DataAccess.Core;

namespace ArmandoShop.DataAccess
{
    /// <summary>
    /// Factory which create instance inject  
    /// his dependencies, as Spring IoC continer.
    /// </summary>
    public class DataAccessFactory
    {

        #region IDAO type factory methods

        public IDAO<Product> GetProductDAO()
        {
            return this.CreateProductDAOImpl();
        }

        public IDAO<Customer> GetCustomerDAO()
        {
            return this.CreateCustomerDAOImpl();
        }

        public IDAO<Category> GetCategoryDAO()
        {
            return this.CreateCategoryDAOImpl();
        }

        public IDAO<Provider> GetProviderDAO()
        {
            return this.CreateProviderDAOImpl();
        }

        public IDAO<Order> GetOrderDAO()
        {
            return this.CreateOrderDAOImpl();
        }

        #endregion

        #region Aware types factory methods

        public ICategoryAwareDAO<Provider> GetProvidercategoryAwareDAO()
        {
            return this.CreateProviderDAOImpl();
        }

        public IProductAwareDAO<Order> GetOrderProductAwareDAO()
        {
            return this.CreateOrderDAOImpl();
        }

        public IUserAwareDAO<Customer> GetCustomerUserAwareDAO()
        {
            return this.CreateCustomerDAOImpl();
        }

        public IUserAwareDAO<Provider> GetProviderUserAwareDAO()
        {
            return this.CreateProviderDAOImpl();
        }


        public IProviderAwareDAO<Category> GetCategoryProviderAwareDAO()
        {
            return this.CreateCategoryDAOImpl();
        }

        public IProductAwareDAO<Category> GetCategoryProductAwareDAO()
        {
            return this.CreateCategoryDAOImpl();
        }

        public IUserDAO GetUserDAO()
        {
            return this.CreateUserDAOImpl();
        }

        public IDAO<Contract> GetContractDAO()
        {
            return this.CreateContractDAOImpl();
        }

        #endregion

        #region Implementations

        private ContractDAO CreateContractDAOImpl()
        {
            ContractDAO dao = new ContractDAO();
            dao.queryExecutor = new QueryExecutor<Contract>();
            dao.updateExecutor = new UpdateExecutor();
            dao.sqlProvider = new ContractSQLProvider();
            return dao;
        }

        private UserDAO CreateUserDAOImpl()
        {
            UserDAO userDAO = new UserDAO();
            userDAO.queryExecutor = new QueryExecutor<User>();
            userDAO.updateExecutor = new UpdateExecutor();
            userDAO.sqlProvider = new UserSQLProvider();

            return userDAO;
        }

        private CategoryDAO CreateCategoryDAOImpl()
        {
            CategoryDAO dao = new CategoryDAO();
            dao.queryExecutor = new QueryExecutor<Category>();
            dao.updateExecutor = new UpdateExecutor();
            dao.sqlProvider = new CategorySQLProvider();
            return dao;
        }

        private ProductDAO CreateProductDAOImpl()
        {
            ProductDAO dao = new ProductDAO();
            dao.queryExecutor = new QueryExecutor<Product>();
            dao.updateExecutor = new UpdateExecutor();
            dao.sqlProvider = new ProductSQLProvider();
            return dao;
        }

        private ProviderDAO CreateProviderDAOImpl()
        {
            ProviderDAO dao = new ProviderDAO();
            dao.queryExecutor = new QueryExecutor<Provider>();
            dao.updateExecutor = new UpdateExecutor();
            dao.sqlProvider = new ProviderSQLProvider();
            return dao;
        }

        private OrderDAO CreateOrderDAOImpl()
        {
            OrderDAO dao = new OrderDAO();
            dao.queryExecutor = new QueryExecutor<Order>();
            dao.updateExecutor = new UpdateExecutor();
            dao.sqlProvider = new OrderSQLProvider();
            return dao;
        }

        private CustomerDAO CreateCustomerDAOImpl()
        {
            CustomerDAO dao = new CustomerDAO();
            dao.queryExecutor = new QueryExecutor<Customer>();
            dao.updateExecutor = new UpdateExecutor();
            dao.sqlProvider = new CustomerSQLProvider();
            return dao;
        }

        #endregion
    }
}
