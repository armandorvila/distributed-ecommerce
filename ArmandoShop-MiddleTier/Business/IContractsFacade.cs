using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmandoShop.Business
{
    public interface IContractsFacade
    {
        IList<Model.Contract> ListContracts();

        long NewContract(Model.Contract contract);

        void DeleteContract(long id);

        void ModifyContract(Model.Contract contract);
    }
}
