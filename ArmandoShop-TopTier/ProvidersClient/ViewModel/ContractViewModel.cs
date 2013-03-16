using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ArmandoShop.ProvidersClient.Model.Services;

namespace ArmandoShop.ProvidersClient.ViewModel
{
    public class ContractViewModel : INotifyPropertyChanged
    {

        private Contract contract;

        public ContractViewModel(Contract contract)
        {
            this.contract = contract;
        }

        #region Properties

        public string Product
        {
            get { return contract.product.name; }
            set { contract.product.name = value; }
        }

        public string Provider
        {
            get { return contract.provider.name; }
            set { contract.provider.name = value; }
        }

        public int Stock
        {
            get { return contract.stock; }
            set { contract.stock = value; }
        }

        #endregion

        #region Dependency proeprties Infraestructure

        public event PropertyChangedEventHandler PropertyChanged;

        void NotifyChange(params string[] ids)
        {
            if (PropertyChanged != null)
                foreach (var id in ids)
                    PropertyChanged(this, new PropertyChangedEventArgs(id));
        }

        #endregion
    }
}
