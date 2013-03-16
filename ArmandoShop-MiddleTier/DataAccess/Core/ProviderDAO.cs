using System;
using ArmandoShop.Model;
using System.Collections.Generic;
using ArmandoShop.DataAccess.Sql;
using ArmandoShop.DataAccess.Util;
using ArmandoShop.DataAccess.Mapping;

namespace ArmandoShop.DataAccess.Core
{
    public class ProviderDAO : ICategoryAwareDAO<Provider>, IUserAwareDAO<Provider>
    {
        internal QueryExecutor<Provider> queryExecutor { get; set; }
        internal UpdateExecutor updateExecutor { get; set; }
        internal SQLProvider<Provider> sqlProvider { get; set; }

        public Provider FindById(long id)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Id", id);
            return queryExecutor.queryForObject(new ProviderMapper(), sqlProvider.FindByISql(), parms);
        }

        public long Create(Provider element)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();

            parms.Add("Name", element.Name);
            parms.Add("Surname", element.Surname);
            parms.Add("Address", element.Address);
            parms.Add("Phone", element.Phone);
            parms.Add("Mail", element.Mail);
            parms.Add("IdUser", element.User.Id);

            return updateExecutor.Persist(sqlProvider.CreateSql(), sqlProvider.GetMaxIdSql(), parms);
        }

        public void Remove(long id)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Id", id);
            this.updateExecutor.Update(sqlProvider.RemoveSql(), parms);
        }

        public void Update(Provider element)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Id", element.Id);
            parms.Add("Name", element.Name);
            parms.Add("Surname", element.Surname);
            parms.Add("Address", element.Address);
            parms.Add("Phone", element.Phone);
            parms.Add("Mail", element.Mail);
            parms.Add("IdUser", element.User.Id);
            this.updateExecutor.Update(sqlProvider.UpdateSql(), parms);
        }

        public IList<Provider> FindAll()
        {
            return this.queryExecutor.query(new ProviderMapper(), sqlProvider.FindAllSql());
        }

        public IList<Category> GetCategoriesByElement(Provider element)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("ProviderId", element.Id);
            string sql = new ConcreteSQLProvider().GetCategoriesByProviderSQL();
            return new QueryExecutor<Category>().query(new CategoryMapper(), sql, parms);
        }


        public void AddCatagorityToElement(Category category, Provider element)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("ProviderId", element.Id);
            parms.Add("categoryId", category.Id);
            string sql = new ConcreteSQLProvider().GetAddProviderTocategorySQL();
            this.updateExecutor.Update(sql, parms);
        }

        public void RemoveCategoryOfElement(Category category, Provider element)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("ProviderId", element.Id);
            parms.Add("categoryId", category.Id);
            string sql = new ConcreteSQLProvider().GetRemoveProviderOfcategorySQL();
            this.updateExecutor.Update(sql, parms);
        }

        public Provider GetElementByUser(User user)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("IdUser", user.Id);
            IList<Provider> providers = this.queryExecutor.query(new ProviderMapper(),
                new ConcreteSQLProvider().GetProvidersByUserSQL(), parms);
            if (providers.Count != 1)
                return null;
            return providers[0];
        }
    }
}
