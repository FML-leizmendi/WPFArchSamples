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
using WPF.Sample.DataLayer;
using WPF.Sample.ViewModelLayer;

namespace WPF.Sample.UserControls
{
    /// <summary>
    /// Lógica de interacción para UserMaintenanceListControl.xaml
    /// </summary>
    public partial class UserMaintenanceListControl : UserControl
    {
        public UserMaintenanceListControl()
        {
            InitializeComponent();
        }

        private UserMaintenanceViewModel _viewModel;

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Set selected item
            _viewModel.Entity = (User)((Button)sender).Tag;
            // Go into edit mode
            _viewModel.BeginEdit(false);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Set Selected item
            _viewModel.Entity = (User)((Button)sender).Tag;

            // Delete user
            DeleteUser();
        }

        private void DeleteUser()
        {
            // Ask if the user wants to delete this user
            if (MessageBox.Show("Delete User " + _viewModel.Entity.LastName + ", "
                                + _viewModel.Entity.FirstName + "?", "Delete?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _viewModel.Delete();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel = (UserMaintenanceViewModel)this.DataContext;
        }
    }
}
