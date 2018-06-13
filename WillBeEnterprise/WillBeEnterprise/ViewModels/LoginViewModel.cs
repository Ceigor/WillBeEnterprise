using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using WillBeEnterprise.Models;
using WillBeEnterprise.Services.Http;
using WillBeEnterprise.ViewModels.Base;
using Xamarin.Forms;

namespace WillBeEnterprise.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; private set; }
        public IHttpService Service { get; private set; }

        public LoginViewModel(IHttpService service)
        {
            Service = service;
            LoginCommand = new Command(async () => await Login());
        }

        private async Task Login()
        {
            
        }
    }
}
