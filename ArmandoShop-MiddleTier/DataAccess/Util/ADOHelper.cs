using System.Data.Common;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace ArmandoShop.DataAccess.Util
{
    internal class ADOHelper
    {
        private static ADOHelper INSATANCE = new ADOHelper();
        private DbProviderFactory providerFactory;
        private DbConnection connection;

        private ADOHelper()
        {   
            string providerFactoryName = ConfigurationManager.AppSettings["dataProvider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            
            this.providerFactory = DbProviderFactories.GetFactory(providerFactoryName);
            this.connection = this.providerFactory.CreateConnection();
            this.connection.ConnectionString = connectionString;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        internal static ADOHelper GetInstance()
        {
            return INSATANCE;
        }

        internal DbCommand GetCommand()
        {
            return this.providerFactory.CreateCommand();
        }

        internal DbConnection GetConnection()
        {
            return this.connection;
        }

    }
}
