using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;
using ArmandoShop.DataAccess.Util;
using ArmandoShop.DataAccess.Mapping;
using ArmandoShop.DataAccess.Sql;

namespace ArmandoShop.DataAccess.Core
{
   public class UserDAO:IUserDAO
    {
       internal QueryExecutor<User> queryExecutor;
       internal UpdateExecutor updateExecutor;
       internal UserSQLProvider sqlProvider;

        public User FindById(long id)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Id" , id);
            return queryExecutor.
                queryForObject(new UserMapper(), sqlProvider.FindByISql(), parms);
        }

        public long Create(User element)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@Username", element.Username);
            parms.Add("@Password", element.Password);
           
            return this.updateExecutor
                .Persist(sqlProvider.CreateSql(),sqlProvider.GetMaxIdSql(),parms);
        }

        public void Remove(long id)
        {

            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@Id", id);
            this.updateExecutor.Update(sqlProvider.UpdateSql(),parms);
        }

        public void Update(User element)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@Id",element.Id);
            parms.Add("@Username", element.Username);
            parms.Add("@Password", element.Password);
  
            this.updateExecutor.Update(sqlProvider.UpdateSql(), parms);
        }

        public IList<User> FindAll()
        {
            return queryExecutor.query(new UserMapper(), "");
        }

        public User FindByUsername(string username)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Username", username);
            IList<User> results = this.queryExecutor.
                query(new UserMapper()
                ,new ConcreteSQLProvider().GetUserByUsername(),parms);
            if (results.Count != 1)
                return null;
            
            return results[0]; 
        }


    }
}
