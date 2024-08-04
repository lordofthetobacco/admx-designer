using System.Collections.ObjectModel;
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

namespace admx_designer;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ControlTypeComboBox.ItemsSource = Enum.GetValues(typeof(EPolicyControlType));
        DataContext = typeof(MainViewModel);
    }

    private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        //DEBUGGING
        //Console.WriteLine($"Window resized - new listview_size {this.ActualHeight - DesignGrid.ActualHeight - 20}"); 
        ListViewDisplay.Height = this.ActualHeight - (DesignGrid.ActualHeight * 2) - 5;
    }

    private void RegistryPathTextBox_LostFocus(object sender, RoutedEventArgs e) {
        string currentString = RegistryPathTextBox.Text.ToUpper().Trim();
        if (currentString.Contains("HKEY_LOCAL_MACHINE")) {
            MachineContextCheckBox.IsChecked = true;
            currentString = currentString.Replace(@"HKEY_LOCAL_MACHINE\", "");
            RegistryPathTextBox.Text = currentString;
            return;
        }
        if (currentString.Contains("HKEY_CURRENT_USER")) {
            MachineContextCheckBox.IsChecked = true;
            currentString = currentString.Replace(@"HKEY_CURRENT_USER\", "");
            RegistryPathTextBox.Text = currentString;
            return;
        }
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
        string registryPath = RegistryPathTextBox.Text;
        string registryKey = RegistryKeyTextBox.Text;
        EPolicyControlType controlType = (EPolicyControlType) ControlTypeComboBox.SelectedItem;
        string policyContext = "";
        if (MachineContextCheckBox.IsChecked == true) {
            policyContext = "Machine";
        }
        if (UserContextCheckBox.IsChecked == true) {
            policyContext = "User";
        };
        if (MachineContextCheckBox.IsChecked == true && UserContextCheckBox.IsChecked == true) {
            policyContext = "Both";
        } else {
            throw new Exception("No context has been specified");
        } 
        MainViewModel.Items.Add(new AdmxPolicyKey(registryKey, controlType, registryPath, policyContext));
        RegistryKeyTextBox.Clear();
    }
}