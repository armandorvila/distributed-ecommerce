using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ArmandoShop.DataAccess.Sql
{
    internal abstract class SQLProvider<T>
    {

        private IDictionary<string, string> sqlContainer = new Dictionary<string, string>();

        protected string GetSql(string key)
        {
            if (!sqlContainer.ContainsKey(key))
            {
                sqlContainer.Add(key,
                    ConfigurationManager.AppSettings[key]);
            }
            return ConfigurationManager.AppSettings[key];
        }

        internal abstract string FindByISql();

        internal abstract string FindAllSql();

        internal abstract string GetMaxIdSql();

        internal abstract string CreateSql();

        internal abstract string UpdateSql();

        internal abstract string RemoveSql();
    }
}
