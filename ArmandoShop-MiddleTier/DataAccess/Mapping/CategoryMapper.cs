using System.Data.Common;
using ArmandoShop.Model;

namespace ArmandoShop.DataAccess.Mapping
{
   internal class CategoryMapper:IRowMapper<Category>
    {
       public Category MapRow(DbDataReader reader)
        {
            Category category = new Category();
            category.Id = reader.GetInt64(0);
            category.Name = reader.GetString(1);
            category.Description = reader.GetString(2);
            return category;
        }
    }
}
