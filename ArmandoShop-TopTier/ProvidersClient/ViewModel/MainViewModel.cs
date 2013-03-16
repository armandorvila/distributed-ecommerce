using System.Windows;
using System.ComponentModel;
using System.Windows.Input;
using ArmandoShop.ProvidersClient.Model;
using ArmandoShop.ProvidersClient.View;
using ArmandoShop.ProvidersClient.Model.Services;
using System;

namespace ArmandoShop.ProvidersClient.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {

        #region Fields

        private ICommand modifyInformationCommand;
        private ICommand removeCategoryCommand;
        private ICommand addCategoryCommand;

        private Provider provider;
        private Category mineSelected;
        private Category newSelected;

        private BindingList<Category> providerCategories;
        private BindingList<Category> restOfCategories;

        private ProvidersBusinessDelegate providersBusinessDelegate;
        private UsersBusinessDelegate usersBusinessDelegate;

        private string oldUserName;

        #endregion

        #region Constructor

        public MainViewModel(User user)
        {
            this.providersBusinessDelegate = new ProvidersBusinessDelegate();
            this.usersBusinessDelegate = new UsersBusinessDelegate();
            this.provider = this.RetrieveProvider(user);
            this.providerCategories = new BindingList<Category>(new CategoryBusinessDelegate().GetCategoriesByProvider(provider));
            this.restOfCategories = new BindingList<Category>(new CategoryBusinessDelegate().GetCategoriesOutProvider(provider));

            this.oldUserName = user.username;

            this.modifyInformationCommand =
                new DelegateCommand(o => ModifyProvider(provider));
            this.removeCategoryCommand =
                new DelegateCommand(o => RemoveCategory(provider, mineSelected));
            this.addCategoryCommand =
                new DelegateCommand(o => AddCategory(provider, newSelected));

           
        }

        #endregion

        public void ShowCategory()
        {
            if (this.mineSelected != null)
            {

                CategoryView view = new CategoryView();
                view.DataContext = new CategoryViewModel(provider, mineSelected);
                view.ShowDialog();
            }
            else
            {
                MessageBox.Show("You must select a Category..");
            }
        }

        #region utility methods

        private Provider RetrieveProvider(User user)
        {
            try
            {
                return providersBusinessDelegate.GetProviderByUser(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error ocurred, sorry!" + ex.Message, "Error!",
                MessageBoxButton.OK, MessageBoxImage.Error,
                MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                Environment.Exit(1);
                return null;
            }
        }

        #endregion

        #region methods for commands

        private void ModifyProvider(Provider provider)
        {
            try
            {
                if (oldUserName.Equals(provider.user.username) ||
                    usersBusinessDelegate.
                    IsUsernameAvaiable(provider.user.username))
                {
                    usersBusinessDelegate.ModifyUser(provider.user);
                    providersBusinessDelegate.ModifyProvider(provider);
                }
                else
                {
                    MessageBox.Show("Invalid Username, try with other..!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error ocurred, sorry!", "Error!",
                    MessageBoxButton.OK, MessageBoxImage.Error,
                    MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void RemoveCategory(Provider provider, Category category)
        {
            if (category == null)
                MessageBox.Show("You have to select a category!!");
            else
                try
                {
                    new CategoryBusinessDelegate().RemoveCategory(provider, category);
                    this.restOfCategories.Add(category);
                    this.providerCategories.Remove(category);
                }
                catch (Exception)
                {
                    MessageBox.Show("An error ocurred, sorry!", "Error!",
                     MessageBoxButton.OK, MessageBoxImage.Error,
                     MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                }
        }

        private void AddCategory(Provider provider, Category category)
        {
            if (category == null)
                MessageBox.Show("You have to select a category!!");
            else
                try
                {
                    new CategoryBusinessDelegate().AddCategory(provider, category);
                    this.restOfCategories.Remove(category);
                    this.providerCategories.Add(category);
                }
                catch (Exception)
                {
                    MessageBox.Show("An error ocurred, sorry!", "Error!",
                        MessageBoxButton.OK, MessageBoxImage.Error,
                        MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                }
        }

        #endregion

        #region Properties

        public string Name
        {
            set { provider.name = value; }
            get { return provider.name; }
        }

        public string Surname
        {
            set { provider.surname = value; }
            get { return provider.surname; }
        }

        public string Address
        {
            set { provider.address = value; }
            get { return provider.address; }
        }

        public string Phone
        {
            set { provider.phone = value; }
            get { return provider.phone; }
        }

        public string Username
        {
            set { provider.user.username = value; }
            get { return provider.user.username; }
        }

        public string Password
        {
            set { provider.user.password = value; }
            get { return provider.user.password; }
        }

        public string Mail
        {
            set { provider.mail = value; }
            get { return provider.mail; }
        }

        public BindingList<Category> ProviderCategories
        {
            set { this.providerCategories = value; }
            get { return providerCategories; }
        }

        public BindingList<Category> RestOfCategories
        {
            set { this.restOfCategories = value; }
            get { return restOfCategories; }
        }

        public ICommand ModifyInformationCommand
        {
            get { return modifyInformationCommand; }
            set { modifyInformationCommand = value; }
        }

        public ICommand RemoveCategoryCommand
        {
            get { return removeCategoryCommand; }
            set { removeCategoryCommand = value; }
        }

        public ICommand AddCategoryCommand
        {
            get { return addCategoryCommand; }
            set { addCategoryCommand = value; }
        }

        public Category MineSelected
        {
            get { return mineSelected; }
            set { mineSelected = value; }
        }

        public Category NewSelected
        {
            get { return newSelected; }
            set { newSelected = value; }
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
