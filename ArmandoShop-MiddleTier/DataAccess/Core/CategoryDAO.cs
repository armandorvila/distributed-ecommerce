using System;
using ArmandoShop.Model;
using System.Collections.Generic;
using ArmandoShop.DataAccess.Sql;
using ArmandoShop.DataAccess.Util;
using ArmandoShop.DataAccess.Mapping;

namespace ArmandoShop.DataAccess.Core
{
    public class CategoryDAO : IProviderAwareDAO<Category>, IProductAwareDAO<Category>
    {
        internal QueryExecutor<Category> queryExecutor { get; set; }
        internal UpdateExecutor updateExecutor { get; set; }
        internal SQLProvider<Category> sqlProvider { get; set; }

        public Category FindById(long id)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Id", id);
            return this.queryExecutor.queryForObject(new CategoryMapper(), 
                sqlProvider.FindByISql(), parms);
        }

        public long Create(Category element)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Name", element.Name);
            parms.Add("Description", element.Description);
            return this.updateExecutor.Persist(sqlProvider.CreateSql(), 
                sqlProvider.GetMaxIdSql(), parms);
        }

        public void Remove(long id)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Id" ,id);
            this.updateExecutor.Update(sqlProvider.RemoveSql(), parms);
        }

        public void Update(Category element)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Id" , element.Id);
            parms.Add("Name" , element.Name);
            parms.Add("Description" , element.Description);
            this.updateExecutor.Update(sqlProvider.UpdateSql(), parms);
        }

        public IList<Category> FindAll()
        {
            return this.queryExecutor.query(new CategoryMapper(), sqlProvider.FindAllSql());
        }

        public IList<Provider> GetProvidersByElement(Category element)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Idcategory", element.Id);
            string sql = new ConcreteSQLProvider().GetProvidersByCategorySQL();
            return new QueryExecutor<Provider>().query(new ProviderMapper(), sql, parms);
        }

        public IList<Product> GetProductsByElement(Category element)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Idcategory", element.Id);
            string sql = new ConcreteSQLProvider().GetProductsByCategorySQL();
            return new QueryExecutor<Product>().query(new ProductMapper(), sql, parms);
        }


       


        public void AddProductToElement(Product product, Category element)
        {
            throw new NotImplementedException();
        }

        public void RemoveProductOfElement(Product product, Category element)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// User Provider DAO, instead of to add the category to provider.
        /// </summary>
        public void AddProviderToElement(Provider provider, Category element)
        {
            throw new NotImplementedException();
        }
       
        /// <summary>
        /// User Provider DAO, instead of to remove the category to provider.
        /// </summary>
        public void RemoveProviderOfElement(Provider provider, Category element)
        {
            throw new NotImplementedException();
        }
    }
}
