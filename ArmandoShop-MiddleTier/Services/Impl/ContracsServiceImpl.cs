using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;

namespace ArmandoShop.Services.Impl
{
    public partial class ArmandoShopService
    {

        public IList<Contract> ListContracts()
        {
            return this.contractsFacade.ListContracts();
        }

        public long NewContract(Contract contract)
        {
            return this.contractsFacade.NewContract(contract);
        }

        public void ModifyContract(Contract contract)
        {
            this.contractsFacade.ModifyContract(contract);
        }

        public void DeleteContract(long id)
        {
            this.contractsFacade.DeleteContract(id);
        }
    }
}
