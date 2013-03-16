using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;
using ArmandoShop.DataAccess.Util;
using ArmandoShop.DataAccess.Sql;
using ArmandoShop.DataAccess.Mapping;

namespace ArmandoShop.DataAccess.Core
{
    class ContractDAO : IDAO<Contract>
    {
        internal QueryExecutor<Contract> queryExecutor;
        internal UpdateExecutor updateExecutor;
        internal SQLProvider<Contract> sqlProvider;

        public Contract FindById(long id)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Id", id);
            return this.queryExecutor.
                queryForObject(new ContractMapper(), sqlProvider.FindByISql(), parms);
        }

        public long Create(Contract element)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("IdProvider", element.Provider.Id);
            parms.Add("IdProduct", element.Product.Id);
            parms.Add("Stock", element.Stock);
            parms.Add("Charged", element.Charged);
            parms.Add("Date", element.Date);

            return updateExecutor.
                Persist(sqlProvider.CreateSql(),
                sqlProvider.GetMaxIdSql(), parms);
        }

        public void Remove(long id)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Id", id);
            this.updateExecutor.Update(sqlProvider.RemoveSql(), parms);

        }

        public void Update(Contract element)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Id", element.Id);
            parms.Add("IdProvider", element.Provider.Id);
            parms.Add("IdProduct", element.Product.Id);
            parms.Add("Stock", element.Stock);
            parms.Add("Charged", element.Charged);
            parms.Add("Date", element.Date);
            this.updateExecutor.Update(sqlProvider.UpdateSql(), parms);
        }

        public IList<Contract> FindAll()
        {
            return this.queryExecutor.
            query(new ContractMapper(), sqlProvider.FindAllSql());
        }
    }
}
