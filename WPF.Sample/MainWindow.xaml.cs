using System.Windows;
using System;
using System.Windows.Threading;
using System.Threading.Tasks;
using WPF.Sample.ViewModelLayer;
using System.Windows.Controls;

namespace WPF.Sample
{
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

            //  Connect to instance of the ciew model created by the XAML
            _viewModel = (MainWindowViewModel)this.Resources["viewModel"];
      
    }

    // Main window's view model class
    private MainWindowViewModel _viewModel = null;

    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
        MenuItem mnu = (MenuItem)sender;
        string cmd = string.Empty;
        // The Tag property contains a command
        // or then name of a user control to load
        if(mnu.Tag!= null)
        {
                cmd = mnu.Tag.ToString();
                if (cmd.Contains(".")){
                    // Display a user control
                    LoadUserControl(cmd);
                }
                else
                {
                    // Process special commands
                    ProcessMenuCommands(cmd);
                }
        }
    }

    private void CloseUsercontrol()
    {
        // Remove current user control
        contentArea.Children.Clear();
    }

    public void DisplayUserControl(UserControl uc)
        {
            CloseUsercontrol();

            contentArea.Children.Add(uc);
        }

    private void LoadUserControl (string controlName)
        {
            Type ucType = null;
            UserControl uc = null;

            // Create a Typr from controlName parameter
            ucType = Type.GetType(controlName);
            if (ucType == null)
            {
                MessageBox.Show("The Control: " + controlName
                                + " does not exist");
            }
            else
            {
                // Create an instance of this control
                uc = (UserControl)Activator.CreateInstance(ucType);
                if (uc != null)
                {
                    // Display control in content area
                    DisplayUserControl(uc);
                }
            }
        }

    private void ProcessMenuCommands(string command)
        {
            switch (command.ToLower())
            {
                case "exit":
                    this.Close();
                    break;
                default:
                    break;

            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadApplication();
            _viewModel.ClearInfoMessages();
        }

        private async Task LoadApplication()
        {
            _viewModel.InfoMessage = "Loading State Codes...";
            await Dispatcher.BeginInvoke(new Action(() =>
            {
                _viewModel.LoadStateCodes();
            }), DispatcherPriority.Background);

            _viewModel.InfoMessage = "Loading Country Codes...";
            await Dispatcher.BeginInvoke(new Action(() =>
            {
                _viewModel.LoadCountryCodes();
            }), DispatcherPriority.Background);

            _viewModel.InfoMessage = "Loading Employee Types...";
            await Dispatcher.BeginInvoke(new Action(() =>
            {
                _viewModel.LoadEmployeeTypes();
            }), DispatcherPriority.Background);
        }
    }
}
