using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.ManagementClient.Model.Services;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;

namespace ArmandoShop.ManagementClient.ViewModel.Categories
{
    public class CategoryViewModel
    {
        private BindingList<Category> categories;
        private Category onTableCategory;
        private ICommand doneCommand;
        private string action;
        

        public CategoryViewModel(BindingList<Category> categories)
        {
            this.onTableCategory = new Category();
            doneCommand = new DelegateCommand(o => Create(onTableCategory));
            this.categories = new BindingList<Category>
                (new DelegateCategoryService().ListCategories());
            this.categories = categories;
            this.action = "Create";
            
        }

        public CategoryViewModel(Category toModify)
        {
            onTableCategory = toModify;
            doneCommand = new DelegateCommand(o => Modify(onTableCategory));
            this.categories = new BindingList<Category>
               (new DelegateCategoryService().ListCategories());
            this.action = "Modify";

        }

        #region Commands Methods

        private void Modify(Category onTable)
        {
            try
            {
                
                new DelegateCategoryService().ModifyCategory(onTable);
            }
            catch (Exception)
            {
                MessageBox.Show("An error ocurred", "Error!",
                        MessageBoxButton.OK, MessageBoxImage.Error,
                        MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void Create(Category onTable)
        {
            try
            {

               onTable.id = new DelegateCategoryService().NewCategory(onTable);
                categories.Add(onTable);
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
            get { return this.onTableCategory; }
            set { onTableCategory = value; }
        }

        public string Name
        {
            get
            {
                return onTableCategory.name;
            }
            set
            {
                onTableCategory.name = value;
            }
        }

        public string Description
        {
            get
            {
                return onTableCategory.description;
            }
            set
            {
                onTableCategory.description = value;
            }
        }

      

        #endregion
    }
}
