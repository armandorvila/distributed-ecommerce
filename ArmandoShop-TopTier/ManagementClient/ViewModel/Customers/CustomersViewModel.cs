using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using ArmandoShop.ManagementClient.Model.Services;
using ArmandoShop.ManagementClient.View.Customers;

namespace ArmandoShop.ManagementClient.ViewModel.Customers
{
    class CustomersViewModel : INotifyPropertyChanged
    {


        #region Fields

        private BindingList<Customer> customers;
        private Customer selectedCustomer;

        private ICommand deleteCustomerCommand;
        private ICommand createCustomerCommand;
        private ICommand modifyCustomerCommand;

        #endregion


        public CustomersViewModel()
        {
            this.customers = new BindingList<Customer>(new DelegateCustomersService().ListCustomers());
            this.deleteCustomerCommand =
                new DelegateCommand(o => DeleteCustomer(selectedCustomer));
            this.createCustomerCommand = new DelegateCommand(o => CreateCustomer());
            this.modifyCustomerCommand = new DelegateCommand(o => ModifyCustomer(selectedCustomer));
        }

        #region Comands Methods

        private void CreateCustomer()
        {
            CustomerView view = new CustomerView();
            view.DataContext = new CustomerViewModel(this.customers);
            view.ShowDialog();

        }

        private void ModifyCustomer(Customer selectedCustomer)
        {
            if (selectedCustomer != null)
            {
                CustomerView view = new CustomerView();
                view.DataContext = new CustomerViewModel(this.selectedCustomer);
                view.ShowDialog();
            }
        }

        private void DeleteCustomer(Customer selectedCustomer)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?:", "Confirmation",
                        MessageBoxButton.YesNo, MessageBoxImage.Question,
                        MessageBoxResult.Cancel, MessageBoxOptions.DefaultDesktopOnly);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    new DelegateCustomersService().
                        DeleteCustomer(selectedCustomer.id);
                    customers.Remove(selectedCustomer);
                    new DelegateUsersService().DeleteUser(selectedCustomer.user.id);
                    if (customers.Count > 0)
                        this.selectedCustomer = customers[0];
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

        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set { selectedCustomer = value; }
        }

        public BindingList<Customer> Customers
        {
            get { return customers; }
            set { customers = value; }
        }

        public ICommand DeleteCustomerCommand
        {
            get { return deleteCustomerCommand; }
            set { deleteCustomerCommand = value; }
        }

        public ICommand CreateCustomerCommand
        {
            get { return createCustomerCommand; }
            set { createCustomerCommand = value; }
        }

        public ICommand ModifyCustomerCommand
        {
            get { return modifyCustomerCommand; }
            set { modifyCustomerCommand = value; }
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
