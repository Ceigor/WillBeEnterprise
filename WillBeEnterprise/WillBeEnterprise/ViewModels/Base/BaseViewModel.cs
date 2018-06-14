using WillBeEnterprise.Bindings;
using WillBeEnterprise.Container;
using WillBeEnterprise.Services.Navigation;

namespace WillBeEnterprise.ViewModels.Base
{
    public abstract class BaseViewModel : ExtendedBindableObject
    {
        protected INavigationService navigationService;

        public BaseViewModel()
        {
            navigationService = IoCcontainer.Resolve<INavigationService>();
        }
    }
}
