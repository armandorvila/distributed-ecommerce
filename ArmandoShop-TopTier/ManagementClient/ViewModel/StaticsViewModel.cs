using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ArmandoShop.ManagementClient.Model.Application;

namespace ArmandoShop.ManagementClient.ViewModel
{
    internal class StaticsViewModel : INotifyPropertyChanged
    {
        #region Fields

        private long providersNumber;
        private long customersNumber;
        private long ordersNumber;
        private long contractsNumber;
        private long productsNumber;
        private long categoriesNumber;
        private string mvProvider;
        private string mvCategory;
        private string mvProduct;

        #endregion

        public StaticsViewModel()
        {
            StaticsHelper helper = new StaticsHelper();
            this.productsNumber = helper.GetNumProducts();
            this.productsNumber = helper.GetNumProducts();
            this.ordersNumber = helper.GetNumOrders();
            this.contractsNumber = helper.GetNumContracts();
            this.customersNumber = helper.GetNumCustomers();
            this.categoriesNumber = helper.GetNumCategories();
            this.mvProduct = helper.GetMostValueProduct();
            this.mvCategory = helper.GetMostValueCategory();
            this.mvProvider = helper.GetMostValueProvider();

        }

        #region Properties

        public long ProvidersNumber
        {
            get { return this.providersNumber; }
            set { this.providersNumber = value; }
        }

        public long ProductsNumber
        {
            get { return this.productsNumber; }
            set { this.productsNumber = value; }
        }

        public long OrdersNumber
        {
            get { return this.ordersNumber; }
            set { this.ordersNumber = value; }
        }

        public long ContractsNumber
        {
            get { return this.contractsNumber; }
            set { this.contractsNumber = value; }
        }

        public long CustomersNumber
        {
            get { return this.customersNumber; }
            set { this.customersNumber = value; }
        }

        public long CategoriesNumber
        {
            get { return this.categoriesNumber; }
            set { this.categoriesNumber = value; }
        }

        public string MvProvider
        {
            get { return this.mvProvider; }
            set { this.mvProvider = value; }
        }

        public string MvProduct
        {
            get { return this.mvProduct; }
            set { this.mvProduct = value; }
        }

        public string MvCategory
        {
            get { return this.mvCategory; }
            set { this.mvCategory = value; }
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
