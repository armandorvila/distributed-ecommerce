using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArmandoShop.WebApplication.Models.Services
{
    public class DelegateContractsService
    {
        public List<Contract> ListContracts()
        {
            using (ContractsServiceClient client = new ContractsServiceClient()){
                return client.ListContracts();
               }
        }
    }
}