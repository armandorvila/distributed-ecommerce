using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;

namespace ArmandoShop.DataAccess.Sql
{
    class ProviderSQLProvider:SQLProvider<Provider>
    {
        internal override string FindByISql()
        {
           return base.GetSql("sql.provider.GetById");
        }

        internal override string FindAllSql()
        {
            return base.GetSql("sql.provider.GetAll");
        }

        internal override string GetMaxIdSql()
        {
            return base.GetSql("sql.provider.GetMaxId");
        }

        internal override string CreateSql()
        {
            return base.GetSql("sql.provider.Create");
        }

        internal override string UpdateSql()
        {
            return base.GetSql("sql.provider.Update");
        }

        internal override string RemoveSql()
        {
            return base.GetSql("sql.provider.Delete");
        }

    }
}
