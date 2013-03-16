using ArmandoShop.DataAccess.Util;
using ArmandoShop.DataAccess.Sql;
using ArmandoShop.DataAccess.Mapping;
using ArmandoShop.Model;
using System.Collections.Generic;

namespace ArmandoShop.DataAccess.Core
{
    public class CustomerDAO: IDAO<Customer>,IUserAwareDAO<Customer>
    {
        internal QueryExecutor<Customer> queryExecutor { get; set; }
        internal UpdateExecutor updateExecutor { get; set; }
        internal SQLProvider<Customer> sqlProvider { get; set; }

        public Customer FindById(long id)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Id", id);
            return queryExecutor.queryForObject(new CustomerMapper(), sqlProvider.FindByISql(), parms);
        }

        public long Create(Customer element)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Name", element.Name);
            parms.Add("Surname", element.Surname);
            parms.Add("Address", element.Address);
            parms.Add("Phone", element.Phone);
            parms.Add("Mail", element.Mail);
            parms.Add("IdUser", element.User.Id);

            return this.updateExecutor.Persist(sqlProvider.CreateSql(), sqlProvider.GetMaxIdSql(), parms);
        }

        public void Remove(long id)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Id", id);
            this.updateExecutor.Update(sqlProvider.RemoveSql(), parms);
        }

        public void Update(Customer element)
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

        public IList<Customer> FindAll()
        {
            return this.queryExecutor.query(new CustomerMapper(),sqlProvider.FindAllSql());
        }

        public Customer GetElementByUser(User user)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("IdUser", user.Id);
            IList<Customer> customers = this.queryExecutor.query(new CustomerMapper(), 
                new ConcreteSQLProvider().GetCustomerByUserSQL(), parms);
            if (customers.Count != 1)
                return null;
            return customers[0];
        }
    }
}
