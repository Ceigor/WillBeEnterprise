using System.Windows.Input;
using WillBeEnterprise.ViewModels.Base;
using WillBeEnterprise.Views;
using Xamarin.Forms;

namespace WillBeEnterprise.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand NavigateToLoginCommand { get; private set; }
        public ICommand NavigateToVideoPlayerCommand { get; private set; }
        public ICommand NavigateToSoundPlayerCommand { get; private set; }

        public MainViewModel()
        {
            NavigateToLoginCommand = new Command(async() => await navigationService.NavigateToAsync<LoginView, LoginViewModel>());
            NavigateToVideoPlayerCommand = new Command(async() => await navigationService.NavigateToAsync<VideoPlayerView, VideoPlayerViewModel>());
            NavigateToSoundPlayerCommand = new Command(async () => await navigationService.NavigateToAsync<SoundPlayerView, SoundPlayerViewModel>());
        }

    }
}
