using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;

namespace ArmandoShop.DataAccess
{
    public interface IUserAwareDAO<T> :IDAO<T>
    {
        T GetElementByUser(User user);
    }
}
