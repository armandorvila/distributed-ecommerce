using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ArmandoShop.ManagementClient.Model.Services;
using System.Windows.Input;
using ArmandoShop.ManagementClient.View.Categories;
using System.Windows;

namespace ArmandoShop.ManagementClient.ViewModel.Categories
{
    class CategoriesViewModel : INotifyPropertyChanged
    {

        #region Fields

        private BindingList<Category> categories;
        private Category selectedCategory;

        private ICommand deleteCategoryCommand;
        private ICommand createCategoryCommand;
        private ICommand modifyCategoryCommand;
        private ICommand detailsCommand;

        #endregion

        public CategoriesViewModel()
        {
            this.categories = new BindingList<Category>(new DelegateCategoryService()
                .ListCategories());
            this.deleteCategoryCommand =
                new DelegateCommand(o => DeleteCategory(selectedCategory));
            this.createCategoryCommand = new DelegateCommand(o => CreateCategory());
            this.modifyCategoryCommand = new DelegateCommand(o => ModifyCategory(selectedCategory));
            this.detailsCommand = new DelegateCommand(o => this.ShowProductsOfSelected(this.selectedCategory));
        }



        #region Comands Methods

        private void ShowProductsOfSelected(Category selected)
        {
             if (selectedCategory != null)
            {
            List<Product> productsOfC = new DelegateProductsService()
                .GetProductsByCategory(selected.id);
            ProductsOfCategory view = new ProductsOfCategory();
            view.DataContext = new ProductsOfCategoryViewModel(productsOfC);
            view.ShowDialog();
            }
        }

        private void CreateCategory()
        {
            CategoryView view = new CategoryView();
            view.DataContext = new CategoryViewModel(this.categories);
            view.ShowDialog();
        }

        private void ModifyCategory(Category selectedCategory)
        {
            if (selectedCategory != null)
            {
                CategoryView view = new CategoryView();
                view.DataContext = new CategoryViewModel(this.selectedCategory);
                view.ShowDialog();
            }
        }

        private void DeleteCategory(Category selectedCategory)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?:", "Confirmation",
                       MessageBoxButton.YesNo, MessageBoxImage.Question,
                       MessageBoxResult.Cancel, MessageBoxOptions.DefaultDesktopOnly);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    new DelegateCategoryService().
                        DeleteCategory(selectedCategory.id);
                    categories.Remove(selectedCategory);
                    if (categories.Count > 0)
                        this.selectedCategory = categories[0];
                }
                catch (Exception)
                {
                    MessageBox.Show("An error ocurred.", "Error!",
                            MessageBoxButton.OK, MessageBoxImage.Error,
                            MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                }
            }

        }

        #endregion

        #region Properties

        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set { selectedCategory = value; }
        }

        public BindingList<Category> Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        public ICommand DeleteCategoryCommand
        {
            get { return deleteCategoryCommand; }
            set { deleteCategoryCommand = value; }
        }

        public ICommand CreateCategoryCommand
        {
            get { return createCategoryCommand; }
            set { createCategoryCommand = value; }
        }

        public ICommand ModifyCategoryCommand
        {
            get { return modifyCategoryCommand; }
            set { modifyCategoryCommand = value; }
        }

        public ICommand DetailsCommand
        { get { return detailsCommand; } 
            set { this.detailsCommand = value; } 
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
