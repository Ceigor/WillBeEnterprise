using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using WillBeEnterprise.Services.Http;
using WillBeEnterprise.Validations;
using WillBeEnterprise.ViewModels.Base;
using Xamarin.Forms;

namespace WillBeEnterprise.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; private set; }
        public IHttpService Service { get; private set; }
        private ValidatableObject<string> username;
        public ValidatableObject<string> Username
        {
            get { return username; }
            set
            {
                username = value;
                RaisePropertyChanged(() => Username);
            }
        }
        private ValidatableObject<string> password;
        public ValidatableObject<string> Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged(() => Password);
            }
        }


        public LoginViewModel(IHttpService service)
        {
            Service = service;
            LoginCommand = new Command(() => Login());
            username = new ValidatableObject<string>();
            password = new ValidatableObject<string>();
            AddValidations();
        }

        private async Task Login()
        {
            Debug.WriteLine(string.Format("Bindeded data = {0}, {1}", Username.Value, Password.Value));

        }

        private void AddValidations()
        {
            username.Validations.Add(new IsNotNullOrEmptyRule { ValidationMessage = Properties.Resources.Strings.UsernameRequired });
            password.Validations.Add(new IsNotNullOrEmptyRule { ValidationMessage = Properties.Resources.Strings.PasswordRequired });
        }
    }
}
