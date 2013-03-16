using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using ArmandoShop.ProvidersClient.ViewModel;
using ArmandoShop.ProvidersClient.View;

namespace ArmandoShop.ProvidersClient
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            
            LoginView view = new LoginView();
            LoginViewModel viewModel = new LoginViewModel(view);
            view.DataContext = viewModel;
            view.Show();
        }
    }
}
