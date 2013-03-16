using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ArmandoShop.ManagementClient.Model.Services;
using System.Windows.Input;
using System.Windows;

namespace ArmandoShop.ManagementClient.ViewModel.Customers
{
    public class CustomerViewModel : INotifyPropertyChanged
    {

        private Customer onTheTable;
        private ICommand doneCommand;
        private BindingList<Customer> customers;
        private string action;


        public CustomerViewModel(BindingList<Customer> customers)
        {
            this.onTheTable = new Customer();
            this.onTheTable.user = new User();
            doneCommand = new DelegateCommand(o => Create(onTheTable));
            this.customers = customers;
            this.action = "Create";

        }

        public CustomerViewModel(Customer toModify)
        {
            onTheTable = toModify;
            
            doneCommand = new DelegateCommand(o => Modify(onTheTable));
            this.action = "Modify";
        }

        #region Commands Methods

        private void Modify(Customer onTheTable)
        {
            try
            {
                if (new DelegateUsersService().IsUsernameAvaiable(onTheTable.user.username))
                {
                    new DelegateUsersService().ModifyUser(onTheTable.user);
                    new DelegateCustomersService().ModifyCustomer(onTheTable);
                }
                else MessageBox.Show("Incorrect Username :" + onTheTable.user.username);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error ocurred:" + ex.Message, "Error!",
                        MessageBoxButton.OK, MessageBoxImage.Error,
                        MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void Create(Customer onTheTable)
        {
            try
            {
                if (new DelegateUsersService().IsUsernameAvaiable(onTheTable.user.username))
                {

                    onTheTable.user.id = new DelegateUsersService().NewUser(onTheTable.user);

                    this.onTheTable.id =
                        new DelegateCustomersService().NewCustomer(this.onTheTable);
                customers.Add(onTheTable);
                }
                else MessageBox.Show("Incorrect Username :" + onTheTable.user.username);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error ocurred:" + ex.Message, "Error!",
                        MessageBoxButton.OK, MessageBoxImage.Error,
                        MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        #endregion

        #region Properties

        public string Action
        {
            get { return this.action; }
            set { this.action = value; }
        }

        public ICommand Done
        {
            get { return doneCommand; }
            set { doneCommand = value; }
        }


        public string Name
        {
            get
            {
                return onTheTable.name;
            }
            set
            {
                onTheTable.name = value;
            }
        }

        public string Mail
        {
            get
            {
                return onTheTable.mail;
            }
            set
            {
                onTheTable.mail = value;
            }

        }

        public string Surname
        {
            get { return onTheTable.surname; }
            set { this.onTheTable.surname = value; }
        }

        public string Address
        {
            get { return onTheTable.address; }
            set { this.onTheTable.address = value; }
        }

        public string Phone
        {
            get { return this.onTheTable.phone; }
            set { this.onTheTable.phone = value; }
        }

        public string Username
        {
            get
            {
                return onTheTable.user.username;
            }
            set
            {
                onTheTable.user.username = value;
            }
        }

        public string Password
        {
            get
            {
                return onTheTable.user.password;
            }
            set
            {
                onTheTable.user.password = value;
            }
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
