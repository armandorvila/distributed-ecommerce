using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;
using ArmandoShop.DataAccess;

namespace ArmandoShop.Business.Contracts
{
    public class ContractsFacadeImpl : IContractsFacade
    {
        private IDAO<Contract> contractDAO;

        public IList<Contract> ListContracts()
        {
            return this.contractDAO.FindAll();
        }

        public long NewContract(Contract contract)
        {
            return this.contractDAO.Create(contract);
        }

        public void DeleteContract(long id)
        {
            this.contractDAO.Remove(id);
        }


        public void ModifyContract(Contract contract)
        {
            this.contractDAO.Update(contract);
        }
    }
}
