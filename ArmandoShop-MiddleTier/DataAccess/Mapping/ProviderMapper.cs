using System.Data.Common;
using ArmandoShop.Model;

namespace ArmandoShop.DataAccess.Mapping
{
    internal class ProviderMapper : IRowMapper<Provider>
    {
        public Provider MapRow(DbDataReader reader)
        {
            Provider provider = new Provider();

            provider.Id = reader.GetInt64(0);
            provider.Name = reader.GetString(1);
            provider.Surname = reader.GetString(2);
            provider.Address = reader.GetString(3);
            provider.Phone = reader.GetString(4);
            provider.Mail = reader.GetString(5);
           
           

            provider.User = this.GetUser(reader);

            return provider;
        }

        private User GetUser(DbDataReader reader)
        {
            User user = new User();
            user.Id = reader.GetInt64(6);
            user.Username = reader.GetString(7);
            user.Password = reader.GetString(8);
            return user;
        }
    }
}
