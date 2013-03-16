using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;
using System.Data.Common;

namespace ArmandoShop.DataAccess.Mapping
{
    class UserMapper:IRowMapper<User>
    {
        public User MapRow(DbDataReader reader)
        {
            User user = new User();

            user.Id = reader.GetInt64(0);
            user.Username = reader.GetString(1);
            user.Password = reader.GetString(2);
            
            return user;
        }
    }
}
