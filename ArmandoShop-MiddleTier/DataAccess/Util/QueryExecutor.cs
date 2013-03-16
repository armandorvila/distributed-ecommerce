using System.Data.Common;
using ArmandoShop.DataAccess.Mapping;
using System.Collections.Generic;
using System;

namespace ArmandoShop.DataAccess.Util
{
    internal class QueryExecutor<T>
    {

        internal IList<T> query(IRowMapper<T> mapper, string sql)
        {
            ADOHelper Helper = ADOHelper.GetInstance();
            DbCommand cmd = Helper.GetCommand();
            DbConnection con = Helper.GetConnection();
            return this.GenericQuery(cmd, con, mapper, sql);

        }

        internal IList<T> query(IRowMapper<T> mapper, string sql, IDictionary<string, object> parms)
        {
            ADOHelper Helper = ADOHelper.GetInstance();
            DbCommand cmd = Helper.GetCommand();
            DbConnection con = Helper.GetConnection();
            this.AddParameters(cmd, parms);
            return this.GenericQuery(cmd, con, mapper, sql);
        }


        internal T queryForObject(IRowMapper<T> mapper, string sql)
        {
            IList<T> objects = this.query(mapper, sql);

            if (objects.Count != 1)
                throw new Exception("There was zero or more of one row.");

            return objects[0];
        }

        internal T queryForObject(IRowMapper<T> mapper, string sql, IDictionary<string, object> parms)
        {
            IList<T> objects = this.query(mapper, sql , parms);

            if (objects.Count != 1)
                throw new Exception("There was zero or more of one row.");

            return objects[0];
        }

        internal IList<T> GenericQuery(DbCommand cmd, DbConnection con, IRowMapper<T> mapper, string sql)
        {
            IList<T> objects = new List<T>();
            cmd.CommandText = sql;
            cmd.Connection = con;
            con.Open();
            try
            {
                DbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objects.Add(mapper.MapRow(reader));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return objects;
        }

        private void AddParameters(DbCommand cmd, IDictionary<string, object> parms)
        {
            foreach (string key in parms.Keys)
            {
                DbParameter parm = cmd.CreateParameter();
                parm.ParameterName = key;
                parm.Value = parms[key];
                cmd.Parameters.Add(parm);
            }
        }
    }
}
