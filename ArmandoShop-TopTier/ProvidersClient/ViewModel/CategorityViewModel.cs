using System.Windows;
using System.ComponentModel;
using System.Windows.Input;
using ArmandoShop.ProvidersClient.Model.Services;
using ArmandoShop.ProvidersClient.Model;
using ArmandoShop.ProvidersClient.View;
using System;

namespace ArmandoShop.ProvidersClient.ViewModel
{
    internal class CategoryViewModel : INotifyPropertyChanged
    {
        #region Fields

        private Category category;
        private Product selectedProduct;
        private Provider provider;
        private int amount;
        private BindingList<Product> products;

        ICommand provideCommand;

        public CategoryViewModel(Provider provider, Category category)
        {
            this.provider = provider;
            this.category = category;
            this.products =
                new BindingList<Product>(new ProductsBusinessDelegate().
                    GetProductsByCategory(category));

            provideCommand = new DelegateCommand(o => ProvideProduct(amount, selectedProduct));
        }

        #endregion

        #region View Logic

        private void ProvideProduct(int amount, Product product)
        {
            if (product == null)
                MessageBox.Show("You have to Select a product..");
            else
                try
                {
                   
                    Contract contract = new Contract();
                    contract.product = selectedProduct;
                    contract.provider = provider;
                    contract.stock = amount;
                    contract.charged = false;
                    contract.date = DateTime.Now;
                    ContractView view = new ContractView();
                    view.DataContext = new ContractViewModel(contract);
                    view.ShowDialog();
                    if (view.DialogResult.HasValue && view.DialogResult.Value)
                    {
                        selectedProduct.stock += amount;
                        contract.product = selectedProduct;
                        new ContractsBusinessDelegate().NewContract(contract);
                        new ProductsBusinessDelegate().ModifyProduct(selectedProduct);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error ocurred.", "Error!",
                        MessageBoxButton.OK, MessageBoxImage.Error,
                        MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                }
        }

        #endregion

        #region Properties

        public BindingList<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }

        public string CategoryName
        {
            get { return this.category.name; }
            set { this.category.name = value; }
        }

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public ICommand ProvideCommand
        {
            get { return provideCommand; }
            set { provideCommand = value; }
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
