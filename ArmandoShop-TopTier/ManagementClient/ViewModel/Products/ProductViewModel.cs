using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.ManagementClient.Model.Services;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;

namespace ArmandoShop.ManagementClient.ViewModel.Products
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private BindingList<Category> categories;
        private Category selectedCategory;
        private Product onTableProduct;
        private ICommand doneCommand;
        private BindingList<Product> products;
        private string action;
        

        public ProductViewModel(BindingList<Product> products)
        {
            this.onTableProduct = new Product();
            doneCommand = new DelegateCommand(o => Create(onTableProduct,selectedCategory));
            this.categories = new BindingList<Category>
                (new DelegateCategoryService().ListCategories());
            this.products = products;
            this.action = "Create";
            if (categories.Count > 0)
                this.selectedCategory = categories[0];
        }

        public ProductViewModel(Product toModify)
        {
            onTableProduct = toModify;
            doneCommand = new DelegateCommand(o => Modify(onTableProduct,selectedCategory));
            this.categories = new BindingList<Category>
               (new DelegateCategoryService().ListCategories());
            this.action = "Modify";
            if(categories.Count>0)
            this.selectedCategory = categories[0];

        }

        #region Commands Methods

        private void Modify(Product onTable,Category selected)
        {
            try
            {
                onTable.category = selected;
                new DelegateProductsService().ModifyProduct(onTable);
            }
            catch (Exception)
            {
                MessageBox.Show("An error ocurred", "Error!",
                        MessageBoxButton.OK, MessageBoxImage.Error,
                        MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void Create(Product onTable,Category selected)
        {
            try
            {
                onTable.category = selected;
                onTable.id = new DelegateProductsService().NewProduct(onTable);
                products.Add(onTable);
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

        public string Action {
            get { return this.action; }
            set { this.action = value; }
        }

        public ICommand Done
        {
            get { return doneCommand; }
            set { doneCommand = value; }
        }

        public BindingList<Category> Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        public Category SelectedCategory
        {
            get { return this.selectedCategory; }
            set { selectedCategory = value; }
        }

        public string Name
        {
            get
            {
                return onTableProduct.name;
            }
            set
            {
                onTableProduct.name = value;
            }
        }

        public string Description
        {
            get
            {
                return onTableProduct.description;
            }
            set
            {
                onTableProduct.description = value;
            }
        }

        public decimal Price
        {
            get
            {
                return onTableProduct.price;
            }
            set
            {
                onTableProduct.price = value;
            }
        }

        public int Stock
        {
            get
            {
                return onTableProduct.stock;
            }
            set
            {
                onTableProduct.stock = value;
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
