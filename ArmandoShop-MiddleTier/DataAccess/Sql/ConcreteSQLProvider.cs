using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ArmandoShop.DataAccess.Sql
{
    internal class ConcreteSQLProvider
    {

        private IDictionary<string, string> sqlContainer = new Dictionary<string, string>();

        private string GetSql(string key)
        {
            if (!sqlContainer.ContainsKey(key))
            {
                sqlContainer.Add(key,
                    ConfigurationManager.AppSettings[key]);
            }
            return ConfigurationManager.AppSettings[key];
        }

        internal string GetCategoriesByProviderSQL()
        {
            return GetSql("sql.provider.GetCategories");
        }

        internal string GetProductsByOrderSQL()
        {
            return GetSql("sql.order.GetProducts");
        }

        internal string GetProvidersByCategorySQL()
        {
            return GetSql("sql.category.GetProviders");
        }


        internal string GetProductsByCategorySQL()
        {
             return GetSql("sql.category.GetProducts");
        }

        internal string GetAddProviderTocategorySQL()
        {
            return "insert into provider_category (id_provider,id_category) values (@ProviderId,@categoryId)";
        }

        internal string GetRemoveProviderOfcategorySQL()
        {
            return "delete from provider_category where id_provider = @ProviderId and id_category= @categoryId";
        }

        internal string GetUserByUsername()
        {
            return GetSql("sql.user.GetByUsername");
        }

        internal string GetCustomerByUserSQL()
        {
            return GetSql("sql.customer.GetByUser");
        }

        internal string GetProvidersByUserSQL()
        {
            return GetSql("sql.provider.GetByUser");
        }

        internal string GetAddProductToOrderSQL()
        {
            return "insert into order_product (id_product,id_order,amount) values (@IdProduct,@IdOrder,@Amount)";
        }

        internal string GetDeleteProductFromOrderSQL()
        {
            return "delete from order_product where id_product=@IdProduct and id_order=@IdOrder";
        }
    }
}
