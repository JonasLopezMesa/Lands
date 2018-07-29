namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion
        #region Properties
        public string Email { get; set; }
        public string Password {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsRemembered { get; set; }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion
        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnabled = true;
        }
        #endregion
        #region Commands
        public ICommand LoginCommand {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error","Debes poner un Email","Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes poner una contraseña", "Aceptar");
                return;
            }
            this.IsEnabled = false;
            this.IsRunning = true;
            if (this.Email != "jonas@gmail.com" || this.Password != "1234" )
            {
                this.IsEnabled = true;
                this.IsRunning = false;
                await Application.Current.MainPage.DisplayAlert("Error", "El usuario o la contraseña no es correcto", "Aceptar");
                this.Password = string.Empty;
                return;
            }
            this.IsEnabled = true;
            this.IsRunning = false;
            await Application.Current.MainPage.DisplayAlert("Ok", "Sigue palante Bustamante", "Aceptar");
            return;
        }

        public ICommand RegisterCommand { get; set; }
        #endregion

        
    }
}
