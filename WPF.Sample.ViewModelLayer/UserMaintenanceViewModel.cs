using Common.Library;
    
namespace WPF.Sample.ViewModelLayer
{
    public class UserMaintenanceViewModel : UserMaintenanceListControlViewModel
    {
        public UserMaintenanceViewModel() : base()
        {
            DisplayStatusMessage("Maintain Users");
        }
    }
}
