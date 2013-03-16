using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmandoShop.ManagementClient.Model.Services
{
    class DelegateCotnractsService
    {
        public List<Contract> ListContracts()
        {
            List<Contract> contracts = new List<Contract>();

            using (ContractsServiceClient client = new ContractsServiceClient())
            {
                contracts = client.ListContracts();
            }

            return contracts;
        }

        public long NewContract(Contract contract)
        {
            long id;

            using (ContractsServiceClient service = new ContractsServiceClient())
            {
                id = service.NewContract(contract);
            }

            return id;
        }

        public void DeleteContract(long id)
        {
            using (ContractsServiceClient service = new ContractsServiceClient())
            {
                service.DeleteContract(id);
            }
        }

        internal void ModifyContract(Contract selected)
        {
            using (ContractsServiceClient service = new ContractsServiceClient())
            {
                service.ModifyContract(selected);
            }
        }
    }
}
