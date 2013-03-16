using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ArmandoShop.ManagementClient.Model.Services;
using System.Windows.Input;
using System.Windows;
using ArmandoShop.ManagementClient.View.Products;

namespace ArmandoShop.ManagementClient.ViewModel.Products
{
    class ProductsViewModel : INotifyPropertyChanged
    {
        #region Fields
    
        private BindingList<Product> products;
        private Product selectedProduct;

        private ICommand deleteProductCommand;
        private ICommand createProductCommand;
        private ICommand modifyProductCommand;

        #endregion

        public ProductsViewModel()
        {
            this.products = new BindingList<Product>(new DelegateProductsService()
                .ListProducts());
            this.deleteProductCommand = 
                new DelegateCommand(o => DeleteProduct(selectedProduct));
            this.createProductCommand = new DelegateCommand(o => CreateProduct());
            this.modifyProductCommand = new DelegateCommand(o => ModifyProduct(selectedProduct));
        }

        #region Comands Methods

        private void CreateProduct()
        {
            ProductView view = new ProductView();
            view.DataContext = new ProductViewModel(this.products);
            view.ShowDialog();
           
        }

        private void ModifyProduct(Product selectedProduct)
        {
            if (selectedProduct != null)
            {
                ProductView view = new ProductView();
                view.DataContext = new ProductViewModel(selectedProduct);
                view.ShowDialog();
            }
        }

        private void DeleteProduct(Product selectedProduct)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?:", "Confirmation",
                        MessageBoxButton.YesNo, MessageBoxImage.Question,
                        MessageBoxResult.Cancel, MessageBoxOptions.DefaultDesktopOnly);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    new DelegateProductsService().
                        DeleteProduct(selectedProduct.id);
                    products.Remove(selectedProduct);
                    if (products.Count > 0)
                        this.selectedProduct = products[0];
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

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; }
        }

        public BindingList<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public ICommand DeleteProductCommand
        {
            get { return deleteProductCommand; }
            set { deleteProductCommand = value; }
        }

        public ICommand CreateProductCommand
        {
            get { return createProductCommand; }
            set { createProductCommand = value; }
        }

        public ICommand ModifyProductCommand
        {
            get { return modifyProductCommand; }
            set { modifyProductCommand = value; }
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
