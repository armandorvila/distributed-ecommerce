using System.Windows;
using System.Windows.Input;
using ArmandoShop.ProvidersClient.ViewModel;
using ArmandoShop.ProvidersClient.Model.Services;

namespace ArmandoShop.ProvidersClient.View
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private MainViewModel viewModel;

        public MainView()
        {
            InitializeComponent();
        }

        /*Here are events only related with views, no model view*/

        private void EnableDataEdition(object sender, RoutedEventArgs e)
        {
            this.ToChangeTextBoxesState(true, false);
        }

        private void UnableDataEdition(object sender, RoutedEventArgs e)
        {
            this.ToChangeTextBoxesState(false, true);
        }

        private void ToChangeTextBoxesState(bool enabled, bool readOnly)
        {
            nameTextBox.IsReadOnly = readOnly;
            nameTextBox.IsEnabled = enabled;
            surnameTextBox.IsReadOnly = readOnly;
            surnameTextBox.IsEnabled = enabled;
            addressTextBox.IsReadOnly = readOnly;
            addressTextBox.IsEnabled = enabled;
            phoneTextBox.IsReadOnly = readOnly;
            phoneTextBox.IsEnabled = enabled;
            usernameTextBox.IsReadOnly = readOnly;
            usernameTextBox.IsEnabled = enabled;
            passwordTextBox.IsEnabled = enabled;
            mailTextBox.IsReadOnly = readOnly;
            mailTextBox.IsEnabled = enabled;
            modifyDataButton.IsEnabled = enabled;
            allowModificationCheckBox.IsChecked = enabled;
        }

        private void ModifyPersonalInformation(object sender, RoutedEventArgs e)
        {
            this.UnableDataEdition(sender, e);
        }

        private void ShowCategory(object sender, RoutedEventArgs e)
        {
            if (viewModel == null)
                this.viewModel = (MainViewModel)this.DataContext;
            viewModel.ShowCategory();
        }

        private void DoubleClickOnCell(object sender, MouseButtonEventArgs e)
        {
            this.ShowCategory(sender, e);
        }
    }
}
