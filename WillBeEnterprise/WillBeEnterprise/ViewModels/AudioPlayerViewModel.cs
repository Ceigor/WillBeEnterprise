using System.Windows.Input;
using WillBeEnterprise.Services.Audio;
using WillBeEnterprise.ViewModels.Base;
using Xamarin.Forms;

namespace WillBeEnterprise.ViewModels
{
    public class AudioPlayerViewModel : BaseViewModel
    {
        private const string PLAY_COMMAND = "Play";
        private const string PAUSE_COMMAND = "Pause";
        private string _commandText;
        public string CommandText
        {
            get { return _commandText; }
            set
            {
                _commandText = value;
                RaisePropertyChanged(() => CommandText);
            }
        }
        private bool _stopped;
        public ICommand PlayPauseCommand { get; private set; }
        private IAudioPlayerService _audioPlayerService;

        public AudioPlayerViewModel()
        {
            _audioPlayerService = DependencyService.Get<IAudioPlayerService>();
            SetAudioPlayer();
            PlayPauseCommand = new Command(() => PlayPauseCommandAction());
        }

        private void SetAudioPlayer()
        {
            _audioPlayerService.OnFinishedPlaying = () =>
            {
                _stopped = true;
                _commandText = PLAY_COMMAND;
            };
            _commandText = PLAY_COMMAND;
            _stopped = true;
        }

        private void PlayPauseCommandAction()
        {
            if(CommandText.Equals(PLAY_COMMAND))
            {
                if (_stopped)
                {
                    _stopped = false;
                    _audioPlayerService.PlayFromFile("Galway.mp3");
                }
                else
                    _audioPlayerService.Play();
                CommandText = PAUSE_COMMAND;
            }
            else
            {
                _audioPlayerService.Pause();
                CommandText = PLAY_COMMAND;
            }
        }
        
    }
}
