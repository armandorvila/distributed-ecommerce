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
using ArmandoShop.ManagementClient.ViewModel.Categories;

namespace ArmandoShop.ManagementClient.View
{
    /// <summary>
    /// Lógica de interacción para CategoriesSection.xaml
    /// </summary>
    public partial class CategoriesSection : UserControl
    {
        private CategoriesViewModel viewModel;

        public CategoriesSection()
        {
            InitializeComponent();
        }

        private void DoubleClickOnCell(object sender, MouseButtonEventArgs e)
        {
            if (this.viewModel == null)
                this.viewModel = (CategoriesViewModel)this.DataContext;
            this.viewModel.ModifyCategoryCommand.Execute(this.viewModel.SelectedCategory);
        }
    }
}
