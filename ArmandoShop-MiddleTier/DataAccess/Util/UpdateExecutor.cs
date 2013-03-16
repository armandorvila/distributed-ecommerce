using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace ArmandoShop.DataAccess.Util
{
    class UpdateExecutor
    {


        internal long Persist(string createSql, string maxIdSql, IDictionary<string, object> parms)
        {
            DbCommand cmd = ADOHelper.GetInstance().GetCommand();
            this.AddParameters(cmd, parms);
            DbConnection con = ADOHelper.GetInstance().GetConnection();
            DbTransaction tx = null;
            long newId = 0;
            try
            {
                con.Open();
                tx = con.BeginTransaction();
                /*Getting a new Id*/
                newId = this.GetMaxId(maxIdSql, con) + 1;
                this.AddParameter(cmd, "Id", newId);
                /*Creating the object*/
                cmd.Connection = con;
                cmd.CommandText = createSql;
                cmd.ExecuteNonQuery();
                /*commit the transaction*/
                tx.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw new InvalidOperationException("Error Ejectuando la transaccion : " + ex.GetType().Name + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return newId;
        }

        internal void Update(string sql, IDictionary<string, object> parms)
        {
            DbCommand cmd = ADOHelper.GetInstance().GetCommand();
            this.AddParameters(cmd, parms);
            DbConnection con = ADOHelper.GetInstance().GetConnection();
            cmd.Connection = con;
            cmd.CommandText = sql;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
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
        }


        private long GetMaxId(string sql, DbConnection con)
        {
            DbCommand cmd = ADOHelper.GetInstance().GetCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            object res = cmd.ExecuteScalar();
            try
            {
                return (long)res;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
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

        private void AddParameter(DbCommand cmd, string name, object value)
        {
            DbParameter id = cmd.CreateParameter();
            id.ParameterName = name;
            id.Value = value;
            cmd.Parameters.Add(id);
        }
    }
}