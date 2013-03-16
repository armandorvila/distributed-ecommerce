using ArmandoShop.Model;

namespace ArmandoShop.DataAccess.Sql
{
    internal class CustomerSQLProvider : SQLProvider <Customer>
    {
        internal override string FindByISql()
        {
            return base.GetSql("sql.customer.GetById");
        }

        internal override string FindAllSql()
        {
            return base.GetSql("sql.customer.GetAll");
        }

        internal override string GetMaxIdSql()
        {
            return base.GetSql("sql.customer.GetMaxId");
        }

        internal override string CreateSql()
        {
            return base.GetSql("sql.customer.Create");
        }

        internal override string UpdateSql()
        {
            return base.GetSql("sql.customer.Update");
        }

        internal override string RemoveSql()
        {
            return base.GetSql("sql.customer.Delete");
        }
    }
}
