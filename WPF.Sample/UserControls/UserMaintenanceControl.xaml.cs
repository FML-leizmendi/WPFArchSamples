using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.Sample.ViewModelLayer;

namespace WPF.Sample.UserControls
{
    /// <summary>
    /// Lógica de interacción para UserMaintenanceControl.xaml
    /// </summary>
    public partial class UserMaintenanceControl : UserControl
    {
        public UserMaintenanceControl()
        {
            InitializeComponent();

            _viewModel = (UserMaintenanceViewModel)this.Resources["viewModel"];


        }
        private UserMaintenanceViewModel _viewModel = null;

        private void CloseButton_Click(object serbder, RoutedEventArgs e)
        {
            _viewModel.Close();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
