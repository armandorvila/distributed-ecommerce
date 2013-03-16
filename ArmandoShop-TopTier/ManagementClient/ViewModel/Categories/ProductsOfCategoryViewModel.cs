using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ArmandoShop.ManagementClient.Model.Services;

namespace ArmandoShop.ManagementClient.ViewModel.Categories
{
    class ProductsOfCategoryViewModel : INotifyPropertyChanged
    {

        private BindingList<Product> products;

        public ProductsOfCategoryViewModel(List<Product> products)
        {
            this.products = new BindingList<Product>(products);
        }

        public BindingList<Product> Products
        { get { return products; } set { this.products = value; } }

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
