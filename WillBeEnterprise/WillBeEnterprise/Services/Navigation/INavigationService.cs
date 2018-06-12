using System.Threading.Tasks;
using WillBeEnterprise.ViewModels.Base;
using Xamarin.Forms;

namespace WillBeEnterprise.Services.Navigation
{
    public interface INavigationService
    {
        Task NavigateToAsync<View, ViewModel>() where View : ContentPage where ViewModel : BaseViewModel;
        Task RemoveCurrentFromBackStackAsync();
    }
}
