using System;
using ArmandoShop.Model;
using System.Collections.Generic;
using ArmandoShop.DataAccess.Sql;
using ArmandoShop.DataAccess.Util;
using ArmandoShop.DataAccess.Mapping;

namespace ArmandoShop.DataAccess.Core
{
   public class OrderDAO:IProductAwareDAO<Order>
    {
       internal QueryExecutor<Order> queryExecutor { get; set; }
       internal UpdateExecutor updateExecutor { get; set; }
       internal SQLProvider<Order> sqlProvider { get; set; }

        public Order FindById(long id)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Id", id);
            return this.queryExecutor.queryForObject(new OrderMapper(), sqlProvider.FindByISql(),parms);
        }

        public long Create(Order element)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
         
            parms.Add("DateOfBuy", element.DateOfBuy);
            parms.Add("DateOfDelivered", element.DateOfDeliver);
            parms.Add("Delivered", element.Delivered);
            parms.Add("IdCustomer",element.Customer.Id);

            return this.updateExecutor.Persist(sqlProvider.CreateSql(),sqlProvider.GetMaxIdSql(), parms);
        }

        public void Remove(long id)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Id", id);
            this.updateExecutor.Update(sqlProvider.RemoveSql(), parms);
        }

        public void Update(Order element)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Id", element.Id);
            parms.Add("DateOfBuy", element.DateOfBuy);
            parms.Add("DateOfDelivered", element.DateOfDeliver);
            parms.Add("Delivered", element.Delivered);
            parms.Add("IdCustomer", element.Customer.Id);

            this.updateExecutor.Update(sqlProvider.UpdateSql(), parms);
        }

        public IList<Order> FindAll()
        {
            return this.queryExecutor.query(new OrderMapper(),sqlProvider.FindAllSql());
        }

        public IList<Product> GetProductsByElement(Order element)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("OrderId", element.Id);
            string sql = new ConcreteSQLProvider().GetProductsByOrderSQL();
            return new QueryExecutor<Product>().query(new ProductMapper(), sql, parms);
        }


        public void AddProductToElement(Product product, Order element)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("IdProduct",product.Id);
            parms.Add("IdOrder", element.Id);
            parms.Add("Amount",element.Amounts[product.Id]);
            string sql = new ConcreteSQLProvider().GetAddProductToOrderSQL();
            this.updateExecutor.Update(sql,parms);
        }

        public void RemoveProductOfElement(Product product, Order element)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("IdProduct", product.Id);
            parms.Add("IdOrder", element.Id);
            string sql = new ConcreteSQLProvider().GetDeleteProductFromOrderSQL();
            this.updateExecutor.Update(sql, parms);
        }
    }
}
