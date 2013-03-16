using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;

namespace ArmandoShop.DataAccess.Sql
{
    internal class OrderSQLProvider:SQLProvider<Order>
    {
        internal override string FindByISql()
        {
            return base.GetSql("sql.orders.GetById");
        }

        internal override string FindAllSql()
        {
            return base.GetSql("sql.orders.GetAll");
        }

        internal override string GetMaxIdSql()
        {
            return base.GetSql("sql.orders.GetMaxId");
        }

        internal override string CreateSql()
        {
            return base.GetSql("sql.orders.Create");
        }

        internal override string UpdateSql()
        {
            return base.GetSql("sql.orders.Update");
        }

        internal override string RemoveSql()
        {
            return base.GetSql("sql.orders.Delete");
        }
    }
}
