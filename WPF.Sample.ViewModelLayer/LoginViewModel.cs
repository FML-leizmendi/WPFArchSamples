using Common.Library;
using System;
using WPF.Sample.DataLayer;
using System.Linq;


namespace WPF.Sample.ViewModelLayer
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel() : base()
        {
            DisplayStatusMessage("Login to Application");

            Entity = new User
            {
                UserName = Environment.UserName
            };
        }
    private User _Entity;

    public User Entity
    {
        get { return _Entity; }
        set
        {
            _Entity = value;
            RaisePropertyChanged("Entity");
        }
    }

        public bool Validate()
        {
            bool ret = false;

            Entity.IsLoggedIn = false;
            ValidationMessages.Clear();
            if (string.IsNullOrEmpty(Entity.UserName))
            {
                AddValidationMessage("UserName", "User name must be filled in");
            }
            if (string.IsNullOrEmpty(Entity.Password))
            {
                AddValidationMessage("Password", "Password must be filled in");
            }

            ret = (ValidationMessages.Count == 0);
            return ret;
        }

        public bool ValidateCredentials()
        {
            bool ret = false;
            SampleDbContext db = null;

            try
            {
                db = new SampleDbContext();

                if (db.Users.Where(u => u.UserName == Entity.UserName)
                    .Count() > 0){
                    ret = true;
                }
                else
                {
                    AddValidationMessage("LoginFailed",
                                            "Invalid user name and/or password.");
                }
            }
            catch (Exception ex)
            {
                PublishException(ex);
            }


            return ret;
        }

        public bool Login()
        {
            bool ret = false;
            if (Validate())
            {
                //Check Credentials in User Table
                if (ValidateCredentials())
                {
                    //Mark as Logged in
                    Entity.IsLoggedIn = true;

                    // Send message that login was successful
                    MessageBroker.Instance.SendMessage(
                        MessageBrokerMessages.LOGIN_SUCCESS, Entity);

                    //Close the user control
                    Close(false);
                    ret = true;
                }
            }
            return ret;
        }

        public override void Close(bool wasCancelled = true)
    {
        if (wasCancelled)
        {
            //Display Informational Message
            MessageBroker.Instance.SendMessage(
                MessageBrokerMessages.DISPLAY_TIMEOUT_INFO_MESSAGE,
                "User NOT Logged In");
        }
        base.Close(wasCancelled);
    }
}
}
