using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ArmandoShop.ManagementClient.Model.Services;
using System.Windows.Input;
using System.Windows;
using ArmandoShop.ManagementClient.View.Providers;

namespace ArmandoShop.ManagementClient.ViewModel.Providers
{
    class ProvidersViewModel : INotifyPropertyChanged
    {

        #region Fields

        private BindingList<Provider> providers;
        private Provider selectedProvider;

        private ICommand deleteProviderCommand;
        private ICommand createProviderCommand;
        private ICommand modifyProviderCommand;

        #endregion


        public ProvidersViewModel()
        {
            this.providers = new BindingList<Provider>(new DelegateProvidersService()
                .ListProviders());
            this.deleteProviderCommand =
                new DelegateCommand(o => DeleteProvider(selectedProvider));
            this.createProviderCommand = new DelegateCommand(o => CreateProvider());
            this.modifyProviderCommand = new DelegateCommand(o => ModifyProvider(selectedProvider));
        }

        #region Comands Methods

        private void CreateProvider()
        {
            ProviderView view = new ProviderView();
            view.DataContext = new ProviderViewModel(this.providers);
            view.ShowDialog();

        }

        private void ModifyProvider(Provider selectedProvider)
        {
            if(selectedProvider != null)
            {
                ProviderView view = new ProviderView();
                view.DataContext = new ProviderViewModel(this.selectedProvider);
                view.ShowDialog();
            }
        }

        private void DeleteProvider(Provider selectedProvider)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?:", "Confirmation",
                        MessageBoxButton.YesNo, MessageBoxImage.Question,
                        MessageBoxResult.No, MessageBoxOptions.DefaultDesktopOnly);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    new DelegateProvidersService().
                        DeleteProvider(selectedProvider.id);
                    providers.Remove(selectedProvider);
                    new DelegateUsersService().DeleteUser(selectedProvider.user.id);
                    if (providers.Count > 0)
                        this.selectedProvider = providers[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error ocurred:" + ex.Message, "Error!",
                            MessageBoxButton.OK, MessageBoxImage.Error,
                            MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        #endregion


        #region Properties

        public Provider SelectedProvider
        {
            get { return selectedProvider; }
            set { selectedProvider = value; }
        }

        public BindingList<Provider> Providers
        {
            get { return providers; }
            set { providers = value; }
        }

        public ICommand DeleteProviderCommand
        {
            get { return deleteProviderCommand; }
            set { deleteProviderCommand = value; }
        }

        public ICommand CreateProviderCommand
        {
            get { return createProviderCommand; }
            set { createProviderCommand = value; }
        }

        public ICommand ModifyProviderCommand
        {
            get { return modifyProviderCommand; }
            set { modifyProviderCommand = value; }
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
