using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;

namespace ArmandoShop.DataAccess.Sql
{
    class ContractSQLProvider:SQLProvider<Contract>
    {
        internal override string FindByISql()
        {
            return base.GetSql("sql.contract.GetById");
        }

        internal override string FindAllSql()
        {
            return base.GetSql("sql.contract.GetAll");
        }

        internal override string GetMaxIdSql()
        {
            return base.GetSql("sql.contract.GetMaxId");
        }

        internal override string CreateSql()
        {
            return base.GetSql("sql.contract.Create");
        }

        internal override string UpdateSql()
        {
            return base.GetSql("sql.contract.Update");
        }

        internal override string RemoveSql()
        {
            return base.GetSql("sql.contract.Delete");
        }
    }
}
