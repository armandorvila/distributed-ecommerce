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

namespace ArmandoShop.ManagementClient.View
{
    /// <summary>
    /// Lógica de interacción para SingleSection.xaml
    /// </summary>
    public partial class SingleSection : Window
    {
        public SingleSection(UserControl content)
        {
            InitializeComponent();
            this.AddChild(content);
        }
    }
}
