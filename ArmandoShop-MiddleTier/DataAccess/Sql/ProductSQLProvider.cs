using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;
using System.Configuration;

namespace ArmandoShop.DataAccess.Sql
{
    internal class ProductSQLProvider: SQLProvider<Product>
    {

        internal override string FindByISql()
        {
           return base.GetSql("sql.product.GetById");
        }

        internal override string FindAllSql()
        {
            return base.GetSql("sql.product.GetAll");
        }

        internal override string GetMaxIdSql()
        {
            return base.GetSql("sql.product.GetMaxId");
        }

        internal override string CreateSql()
        {
            return base.GetSql("sql.product.Create");
        }

        internal override string UpdateSql()
        {
            return base.GetSql("sql.product.Update");
        }

        internal override string RemoveSql()
        {
            return base.GetSql("sql.product.Delete");
        }
    }
}
