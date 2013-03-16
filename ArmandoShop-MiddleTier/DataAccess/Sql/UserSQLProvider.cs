using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;

namespace ArmandoShop.DataAccess.Sql
{
    class UserSQLProvider:SQLProvider<User>
    {
        internal override string FindByISql()
        {
            return base.GetSql("sql.user.GetById");
        }

        internal override string FindAllSql()
        {
            return base.GetSql("sql.user.GetAll");
        }

        internal override string GetMaxIdSql()
        {
            return base.GetSql("sql.user.GetMaxId");
        }

        internal override string CreateSql()
        {
            return base.GetSql("sql.user.Create");
        }

        internal override string UpdateSql()
        {
            return base.GetSql("sql.user.Update");
        }

        internal override string RemoveSql()
        {
            return base.GetSql("sql.user.Delete");
        }
    }
}
