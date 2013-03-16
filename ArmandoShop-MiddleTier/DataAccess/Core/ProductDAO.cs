using ArmandoShop.Model;
using ArmandoShop.DataAccess.Util;
using System.Collections.Generic;
using ArmandoShop.DataAccess.Mapping;
using ArmandoShop.DataAccess.Sql;

namespace ArmandoShop.DataAccess.Core
{
    public class ProductDAO :IDAO<Product>
    {
        internal QueryExecutor<Product> queryExecutor { get; set;}

        internal UpdateExecutor updateExecutor { get; set;}

        internal SQLProvider<Product> sqlProvider { get; set; }
     

        public Product FindById(long id)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Id", id);
            return queryExecutor.queryForObject(new ProductMapper(), sqlProvider.FindByISql(), parms);
        }

        public long Create(Product element)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Name", element.Name);
            parms.Add("Price", element.Price);
            parms.Add("Stock", element.Stock);
            parms.Add("Description", element.Description);
            parms.Add("Idcategory", element.Category.Id);

            return this.updateExecutor.Persist(sqlProvider.CreateSql(), sqlProvider.GetMaxIdSql(), parms);
        }

        public void Remove(long id)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Id", id);
            this.updateExecutor.Update(sqlProvider.RemoveSql(), parms);
        }

        public void Update(Product element)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Id", element.Id);
            parms.Add("Name", element.Name);
            parms.Add("Price", element.Price);
            parms.Add("Stock", element.Stock);
            parms.Add("Description", element.Description);
            parms.Add("Idcategory", element.Category.Id);
            this.updateExecutor.Update(sqlProvider.UpdateSql(), parms);
        }

        public IList<Product> FindAll()
        {
            return this.queryExecutor.query(new ProductMapper(), sqlProvider.FindAllSql());
        }

    }
}