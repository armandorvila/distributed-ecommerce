using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ArmandoShop.Model;

namespace ArmandoShop.Services.Contracts
{
    [ServiceContract(Namespace = "http://ArmandoShop.ContractsService")]
    public interface IContractsService
    {
        [OperationContract]
        IList<Contract> ListContracts();

        [OperationContract]
        long NewContract(Contract contract);

        [OperationContract]
        void ModifyContract(Contract contract);

        [OperationContract]
        void DeleteContract(long id);
    }
}
