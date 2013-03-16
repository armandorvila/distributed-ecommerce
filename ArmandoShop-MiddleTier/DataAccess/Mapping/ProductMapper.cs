using ArmandoShop.Model;
using System.Data.Common;

namespace ArmandoShop.DataAccess.Mapping
{
    internal class ProductMapper:IRowMapper<Product>
    {
        public Product MapRow(DbDataReader reader)
        {
            Product product = new Product();
            /*Be care full, the order of extractionmust 
             * be the same of sql proyection */
            product.Id = reader.GetInt64(0);
            product.Name = reader.GetString(1);
            product.Stock = reader.GetInt32(2);
            product.Price = reader.GetDecimal(3);
            product.Description = reader.GetString(4);

            product.Category = this.GetCategory(reader);

            return product;
        }

        private Category GetCategory(DbDataReader reader)
        {
            Category category = new Category();

            category.Id = reader.GetInt64(5);
            category.Name = reader.GetString(6);
            category.Description = reader.GetString(7);

            return category;
        }
    }
}
