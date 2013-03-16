using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;

namespace ArmandoShop.DataAccess
{
    public interface IUserDAO:IDAO<User>
    {
         User FindByUsername(string username);
    }
}
