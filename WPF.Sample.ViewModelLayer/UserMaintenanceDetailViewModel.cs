using Common.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Sample.DataLayer;

namespace WPF.Sample.ViewModelLayer 
{
    public class UserMaintenanceDetailViewModel :UserMaintenanceListViewModel
    {
        private User  _Entity;
            
        public User Entity
        {
            get { return _Entity; }
            set { 
                _Entity = value;
                RaisePropertyChanged("Entity");
            }
        }

        public override void LoadUsers()
        {
            base.LoadUsers();

            // Set default user
            if (Users.Count > 0)
            {
                Entity = Users[0];
            }
        }

    }
}
