using System.ComponentModel;
using System.Windows.Input;
using ArmandoShop.ManagementClient.View;
using ArmandoShop.ManagementClient.ViewModel.Categories;
using ArmandoShop.ManagementClient.ViewModel.Customers;
using ArmandoShop.ManagementClient.ViewModel.Products;
using ArmandoShop.ManagementClient.ViewModel.Providers;
using ArmandoShop.ManagementClient.ViewModel.Transactions;

using System.Windows.Controls;

namespace ArmandoShop.ManagementClient.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        #region Fields

        private StaticsViewModel staticsViewModel;
        private ProductsViewModel productsViewModel;
        private CategoriesViewModel categoriesViewModel;
        private TransactionsViewModel transactionsViewModel;
        private ProvidersViewModel providersViewModel;
        private CustomersViewModel customerViewModel;

        private ICommand goToStaticsCommand;
        private ICommand goToProductsCommand;
        private ICommand goToCategoriesCommand;
        private ICommand goToProvidersCommand;
        private ICommand goToCustomersCommand;
        private ICommand goToTransactionsCommand;

        #endregion

        #region Constructors

        public MainViewModel()
        {
            this.staticsViewModel = new StaticsViewModel();
            this.productsViewModel = new ProductsViewModel();
            this.categoriesViewModel = new CategoriesViewModel();
            this.providersViewModel = new ProvidersViewModel();
            this.customerViewModel = new CustomersViewModel();
            this.transactionsViewModel = new TransactionsViewModel();

            this.goToStaticsCommand = new DelegateCommand(o => GoToStaticsSection());
            this.goToProductsCommand = new DelegateCommand(o => GoToProductsSection());
            this.goToCategoriesCommand = new DelegateCommand(o => GoToCategoriesSection());
            this.goToProvidersCommand = new DelegateCommand(o => GoToProvidersSection());
            this.goToCustomersCommand = new DelegateCommand(o => GoToCustomersSection());
            this.goToTransactionsCommand = new DelegateCommand(o => GoToTransactionsSection());
        }

        #endregion

        #region Commands Methods

        private void GoToStaticsSection()
        {
            UserControl staticsSection = new StaticsSection();
            staticsSection.DataContext = this.staticsViewModel;
            new SingleSection(staticsSection).Show();
        }

        private void GoToProductsSection()
        {
            UserControl productsSection = new ProductsSection();
            productsSection.DataContext = this.productsViewModel;
            new SingleSection(productsSection).Show();
        }

        private void GoToCategoriesSection()
        {
            UserControl categoriesSection = new CategoriesSection();
            categoriesSection.DataContext = this.categoriesViewModel;
            new SingleSection(categoriesSection).Show();
        }

        private void GoToCustomersSection()
        {
            UserControl customersSection = new CustomersSection();
            customersSection.DataContext = this.customerViewModel;
            new SingleSection(customersSection).Show();
        }

        private void GoToProvidersSection()
        {
            UserControl providersSection = new ProvidersSection();
            providersSection.DataContext = this.providersViewModel;
            new SingleSection(providersSection).Show();
        }

        private void GoToTransactionsSection()
        {
            UserControl transactionsSection = new TransactionsSection();
            transactionsSection.DataContext = this.transactionsViewModel;
            new SingleSection(transactionsSection).Show();
        }

        #endregion

        #region Commands Properties

        public ICommand GoToStaticsCommand {
            get { return goToStaticsCommand; }
            set { goToStaticsCommand = value; }
        }

        public ICommand GoToProductsCommand
        {
            get { return goToProductsCommand; }
            set { goToProductsCommand = value; }
        }

        public ICommand GoToCategoriesCommand
        {
            get { return goToCategoriesCommand; }
            set { goToCategoriesCommand = value; }
        }

        public ICommand GoToProvidersCommand
        {
            get { return goToProvidersCommand; }
            set { goToProvidersCommand = value; }
        }

        public ICommand GoToCustomersCommand
        {
            get { return goToCustomersCommand; }
            set { goToCustomersCommand = value; }
        }

        public ICommand GoToTransactionsCommand
        {
            get { return goToTransactionsCommand; }
            set { goToTransactionsCommand = value; }
        }

        #endregion

        #region Delegated View Models

        public StaticsViewModel StaticsViewModel
        {
            get { return this.staticsViewModel; }
            set { this.staticsViewModel = value; }
        }

        public ProductsViewModel ProductsViewModel
        {
            get { return productsViewModel; }
            set { productsViewModel = value; }
        }

        public CategoriesViewModel CategoriesViewModel
        {
            get { return categoriesViewModel; }
            set { categoriesViewModel = value; }
        }

        public TransactionsViewModel TransactionsViewModel
        {
            get { return transactionsViewModel; }
            set { transactionsViewModel = value; }
        }

        public ProvidersViewModel ProvidersViewModel
        {
            get { return providersViewModel; }
            set { providersViewModel = value; }
        }

        public CustomersViewModel CustomersViewModel
        {
            get { return customerViewModel; }
            set { customerViewModel = value; }
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
