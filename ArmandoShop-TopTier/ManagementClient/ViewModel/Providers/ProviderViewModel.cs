using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ArmandoShop.ManagementClient.Model.Services;
using System.Windows;
using System.Windows.Input;

namespace ArmandoShop.ManagementClient.ViewModel.Providers
{
    class ProviderViewModel : INotifyPropertyChanged
    {

        private Provider onTheTable;
        private ICommand doneCommand;
        private BindingList<Provider> providers;
        private string action;


        public ProviderViewModel(BindingList<Provider> providers)
        {
            this.onTheTable = new Provider();
            this.onTheTable.user = new User();
            doneCommand = new DelegateCommand(o => Create(onTheTable));
            this.providers = providers;
            this.action = "Create";

        }

        public ProviderViewModel(Provider toModify)
        {
            onTheTable = toModify;
           
            doneCommand = new DelegateCommand(o => Modify(onTheTable));
            this.action = "Modify";
        }

        #region Commands Methods

        private void Modify(Provider onTheTable)
        {
            try
            {
                if (new DelegateUsersService().IsUsernameAvaiable(onTheTable.user.username))
                {
                new DelegateUsersService().ModifyUser(onTheTable.user);
                new DelegateProvidersService().ModifyProvider(this.onTheTable);
                }
                else MessageBox.Show("Incorrect Username :" + onTheTable.user.username);
            }
            catch (Exception)
            {
                MessageBox.Show("An error ocurred.", "Error!",
                        MessageBoxButton.OK, MessageBoxImage.Error,
                        MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void Create(Provider onTheTable)
        {
            try
            {
                if (new DelegateUsersService().IsUsernameAvaiable(onTheTable.user.username))
                {
                    onTheTable.user.id = new DelegateUsersService().NewUser(onTheTable.user);
          
                    this.onTheTable.id =
                        new DelegateProvidersService().NewProvider(this.onTheTable);
                    providers.Add(this.onTheTable);
                }
                else MessageBox.Show("Incorrect Username :" + onTheTable.user.username);
            }
            catch (Exception)
            {
                MessageBox.Show("An error ocurred", "Error!",
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

        public string Surname
        {
            get
            {
                return onTheTable.surname;
            }
            set
            {
                onTheTable.surname = value;
            }
        }

        public string Address
        {
            get
            {
                return onTheTable.address;
            }
            set
            {
                onTheTable.address = value;
            }
        }
        public string Phone
        {
            get
            {
                return onTheTable.phone;
            }
            set
            {
                onTheTable.phone = value;
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
