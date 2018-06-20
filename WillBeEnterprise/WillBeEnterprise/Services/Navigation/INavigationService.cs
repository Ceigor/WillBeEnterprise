using System.Threading.Tasks;
using WillBeEnterprise.ViewModels.Base;
using Xamarin.Forms;

namespace WillBeEnterprise.Services.Navigation
{
    public interface INavigationService
    {
        Task NavigateToAsync<View, ViewModel>() where View : Page where ViewModel : BaseViewModel;
        Task NavigateToAsync<View, ViewModel>(ViewModel viewModel) where View : Page where ViewModel : BaseViewModel;
        Task RemoveCurrentFromBackStackAsync();
    }
}
