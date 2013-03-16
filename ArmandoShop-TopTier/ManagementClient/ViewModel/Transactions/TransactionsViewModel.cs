using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ArmandoShop.ManagementClient.Model.Services;
using System.Windows.Input;
using System.Windows;

namespace ArmandoShop.ManagementClient.ViewModel.Transactions
{
    class TransactionsViewModel : INotifyPropertyChanged
    {
        #region Fields

        private BindingList<Contract> contracts;
        private BindingList<Order> orders;

        private Order selectedOrder;
        private Contract selectedContract;

        private ICommand deleteOrderCommand;
        private ICommand deliverOrderCommand;
        private ICommand deleteContractCommand;
        private ICommand markAsPaidCommand;

        #endregion

        public TransactionsViewModel()
        {
            this.contracts = new BindingList<Contract>(new DelegateCotnractsService().ListContracts());
            this.orders = new BindingList<Order>(new DelegateOrdersService().ListOrders());

            this.deleteOrderCommand = new DelegateCommand(o => DeleteOrder(selectedOrder));
            this.deliverOrderCommand = new DelegateCommand(o => DeliverOrder(selectedOrder));
            this.deleteContractCommand = new DelegateCommand(o => DeleteContract(selectedContract));
            this.markAsPaidCommand = new DelegateCommand(o => MarkAsPaid(selectedContract));
        }

        #region Commands Methods

        private void DeliverOrder(Order selected){
            if (selectedOrder != null)
            {
                try
                {
                    selected.delivered = true;
                    new DelegateOrdersService().ModifyOrder(selected);
                   
                }
                catch (Exception)
                {
                    MessageBox.Show("An error ocurred", "Error!",
                            MessageBoxButton.OK, MessageBoxImage.Error,
                            MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        private void DeleteOrder(Order selected)
        {
            if (selectedOrder != null)
            {try
                {
                new DelegateOrdersService().DeleteOrder(selected.id);
                this.orders.Remove(selected);
            }
                catch (Exception)
                {
                    MessageBox.Show("An error ocurred", "Error!",
                            MessageBoxButton.OK, MessageBoxImage.Error,
                            MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        private void DeleteContract(Contract selected)
        {
            if (selectedContract != null)
            {
                try
                {
                    new DelegateCotnractsService().DeleteContract(selected.id);
                    this.contracts.Remove(selected);
                }
                catch (Exception)
                {
                    MessageBox.Show("An error ocurred", "Error!",
                            MessageBoxButton.OK, MessageBoxImage.Error,
                            MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        private void MarkAsPaid(Contract selected)
        {
            if (selectedContract != null)
            {try
                {
                    selected.charged = true;
                new DelegateCotnractsService().ModifyContract(selected);
            }
                catch (Exception)
                {
                    MessageBox.Show("An error ocurred", "Error!",
                            MessageBoxButton.OK, MessageBoxImage.Error,
                            MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                
            }
            }
        }

        #endregion


        #region Properties

        public BindingList<Contract> Contracts
        {
            get { return this.contracts; }
            set { this.contracts = value; }
        }

        public BindingList<Order> Orders
        {
            get { return this.orders; }
            set { this.orders = value; }
        }

        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set { selectedOrder = value; }
        }

        public Contract SelectedContract
        {
            get { return selectedContract; }
            set { selectedContract = value; }
        }

        public ICommand DeleteOrderCommand
        {
            get { return this.deleteOrderCommand; }
            set { deleteOrderCommand = value; }
        }

        public ICommand DeliverOrderCommand
        {
            get { return this.deliverOrderCommand; }
            set { deliverOrderCommand = value; }
        }

        public ICommand DeleteContractCommand
        {
            get { return deleteContractCommand; }
            set { deleteContractCommand = value; }
        }
        public ICommand MarkAsPaidCommand
        {
            get { return this.markAsPaidCommand; }
            set { markAsPaidCommand = value; }
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
