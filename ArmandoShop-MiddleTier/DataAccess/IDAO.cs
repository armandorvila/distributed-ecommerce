
using System.Collections.Generic;
namespace ArmandoShop.DataAccess
{

    public interface IDAO <T>
    {
        T FindById(long id);

        long Create(T element);

        void Remove(long id);

        void Update(T element);

        IList<T> FindAll();

    }
}
