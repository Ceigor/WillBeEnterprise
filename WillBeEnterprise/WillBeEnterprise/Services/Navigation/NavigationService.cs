using System.Threading.Tasks;
using WillBeEnterprise.Exceptions;
using WillBeEnterprise.ViewModels.Base;
using WillBeEnterprise.Views.Factory;
using Xamarin.Forms;

namespace WillBeEnterprise.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateToAsync<View, ViewModel>(ViewModel viewModel)
           where View : Page
           where ViewModel : BaseViewModel
        {
            View page = ViewsFactory.CreateView<View>();
            page.BindingContext = viewModel;
            await GetMainPage().PushAsync(page);
        }

        public async Task NavigateToAsync<View, ViewModel>()
            where View : Page
            where ViewModel : BaseViewModel
        {
            View page = ViewsFactory.CreateBindedView<View, ViewModel>();
            await GetMainPage().PushAsync(page);
        }

        private NavigationPage GetMainPage()
        {
            var mainPage = Application.Current.MainPage;
            if (!(mainPage is NavigationPage))
                throw InvalidTypeException.CreateExpectedActualException(typeof(NavigationPage), mainPage.GetType());
            return mainPage as NavigationPage;
        }

        public async Task RemoveCurrentFromBackStackAsync()
        {
            await GetMainPage().Navigation.PopAsync();
        }
    }
}
