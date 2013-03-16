using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;

namespace ArmandoShop.DataAccess.Sql
{
    internal class CategorySQLProvider: SQLProvider<Category>
    {
        internal override string FindByISql()
        {
            return base.GetSql("sql.category.GetById");
        }

        internal override string FindAllSql()
        {
            return base.GetSql("sql.category.GetAll");
        }

        internal override string GetMaxIdSql()
        {
            return base.GetSql("sql.category.GetMaxId");
        }

        internal override string CreateSql()
        {
            return base.GetSql("sql.category.Create");
        }

        internal override string UpdateSql()
        {
            return base.GetSql("sql.category.Update");
        }

        internal override string RemoveSql()
        {
            return base.GetSql("sql.category.Delete");
        }
    }
}
