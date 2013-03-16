using System.Data.Common;

namespace ArmandoShop.DataAccess.Mapping
{
    internal interface IRowMapper<T>
    {
         T MapRow(DbDataReader reader);
    }
}
