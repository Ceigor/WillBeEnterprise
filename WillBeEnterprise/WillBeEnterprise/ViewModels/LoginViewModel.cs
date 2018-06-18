using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using WillBeEnterprise.Services.Http;
using WillBeEnterprise.Validations;
using WillBeEnterprise.ViewModels.Base;
using WillBeEnterprise.Views;
using Xamarin.Forms;

namespace WillBeEnterprise.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand ValidateEmailCommand { get; private set; }
        public ICommand ValidatePasswordCommand { get; private set; }
        public ICommand LoginCommand { get; private set; }
        public IHttpService Service { get; private set; }
        private ValidatableObject<string> email;
        public ValidatableObject<string> Email
        {
            get
            {
                Debug.WriteLine("Someone is checking Email...");
                return email;
            }
            set
            {
                email = value;
                RaisePropertyChanged(() => Email);
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
            ValidateEmailCommand = new Command(() => ValidateEmail());
            ValidatePasswordCommand = new Command(() => ValidatePassword());
            LoginCommand = new Command(async () => await Login());
            SetValidations();
        }

        private bool Validate()
        {
            return ValidateEmail() && ValidatePassword();
        }

        private bool ValidateEmail()
        {
            Debug.WriteLine("Validating Email...");
            return email.Validate();
        }

        private bool ValidatePassword()
        {
            Debug.WriteLine("Validating Password...");
            return password.Validate();
        }

        private async Task Login()
        {
            bool validated = Validate();
            Debug.WriteLine(string.Format("Bindeded data = {0}, {1}", Email.Value, Password.Value));
            Debug.WriteLine("Validation Result = " + validated);
            if (validated)
                await navigationService.NavigateToAsync<SetYourGoalFirstView, SetYourGoalViewModel>();
        }

        private void SetValidations()
        {
            email = new ValidatableObject<string>();
            password = new ValidatableObject<string>();
            email.ValidationRule = new IsNotNullOrEmptyRule { ValidationMessage = Properties.Resources.Strings.EmailRequired };
            password.ValidationRule = new IsNotNullOrEmptyRule { ValidationMessage = Properties.Resources.Strings.PasswordRequired };
        }
    }
}
