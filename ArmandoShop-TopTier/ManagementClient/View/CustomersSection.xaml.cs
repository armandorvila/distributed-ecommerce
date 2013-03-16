using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ArmandoShop.ManagementClient.ViewModel.Customers;

namespace ArmandoShop.ManagementClient.View
{
    /// <summary>
    /// Lógica de interacción para CustomersSection.xaml
    /// </summary>
    public partial class CustomersSection : UserControl
    {
        private CustomersViewModel viewModel;

        public CustomersSection()
        {
            InitializeComponent();
        }

        private void DoubleClickOnCell(object sender, MouseButtonEventArgs e)
        {
            if (this.viewModel == null)
                this.viewModel = (CustomersViewModel)this.DataContext;
            this.viewModel.ModifyCustomerCommand.Execute(this.viewModel.SelectedCustomer);
        }
    }
}
