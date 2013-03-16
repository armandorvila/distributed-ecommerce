using System.Windows;
using System.ComponentModel;
using System.Windows.Input;
using ArmandoShop.ProvidersClient.Model.Services;
using ArmandoShop.ProvidersClient.Model;
using ArmandoShop.ProvidersClient.View;
using System;

namespace ArmandoShop.ProvidersClient.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        private string username;
        private string password;
        private LoginView asociatedView;

        private ICommand loginCommand;

        public LoginViewModel(LoginView asociatedView)
        {
            this.asociatedView = asociatedView;
            loginCommand = new DelegateCommand(o => Login(username, password));
        }

        /// <summary>
        /// Method for loginCommand, it is acord to Action delegate.
        /// </summary>
        private void Login(string username, string password)
        {
            try
            {
                User user = new UsersBusinessDelegate().Login(username, password);
                if (user == null)
                    MessageBox.
                        Show("Invalid credentials: " + username + "," + password);
                else
                {
                    MainView view = new MainView();
                    view.DataContext = new MainViewModel(user);
                    view.Show();
                    asociatedView.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error ocurred:" + ex.Message , "Error!", 
                    MessageBoxButton.OK, MessageBoxImage.Error, 
                    MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        #region Properties

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                NotifyChange("username");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyChange("password");
            }
        }

        public ICommand LoginCommand
        {
            get { return loginCommand; }
            set { loginCommand = value; }
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
