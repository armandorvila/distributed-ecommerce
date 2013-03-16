using System.Windows;
using ArmandoShop.ManagementClient.View;
using ArmandoShop.ManagementClient.ViewModel;
using System.Runtime;
using ArmandoShop.ManagementClient.Model.Services;
using System;

namespace ArmandoShop.ManagementClient
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void LoadMainView(object sender, StartupEventArgs e)
        {
            if (this.TestConnection())
            {
                MainView view = new MainView();
                view.DataContext = new MainViewModel();
                view.Show();
            }
            else
            {
                MessageBox.Show("Check the connection please!", "Error!",
                            MessageBoxButton.OK, MessageBoxImage.Error,
                            MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                Environment.Exit(1);
            }
        }

        private bool TestConnection()
        {
            try
            {
                new DelegateUsersService().IsUsernameAvaiable("a");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
