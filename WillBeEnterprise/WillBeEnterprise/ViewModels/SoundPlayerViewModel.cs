using System.Diagnostics;
using System.Windows.Input;
using WillBeEnterprise.Services.Sound;
using WillBeEnterprise.ViewModels.Base;
using Xamarin.Forms;

namespace WillBeEnterprise.ViewModels
{
    public class SoundPlayerViewModel : BaseViewModel
    {
        public ICommand PlayCommand { get; private set; }
        private ISoundService _soundService;

        public SoundPlayerViewModel()
        {
            PlayCommand = new Command(() => Play());
            _soundService = DependencyService.Get<ISoundService>();
        }

        private void Play()
        {
            Debug.WriteLine("Trying to play...");
            _soundService.Play();
        }
    }
}
