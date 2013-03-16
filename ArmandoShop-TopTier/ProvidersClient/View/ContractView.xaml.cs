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
using System.Windows.Shapes;

namespace ArmandoShop.ProvidersClient.View
{
    /// <summary>
    /// Lógica de interacción para ContractView.xaml
    /// </summary>
    public partial class ContractView : Window
    {
        public ContractView()
        {
            InitializeComponent();
        }

        private void ConfirContract(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
