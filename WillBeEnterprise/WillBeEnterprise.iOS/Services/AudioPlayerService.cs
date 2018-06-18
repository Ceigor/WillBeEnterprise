using AVFoundation;
using Foundation;
using System;
using WillBeEnterprise.Services.Audio;

namespace WillBeEnterprise.iOS.Services
{
    public class AudioPlayerService : IAudioPlayerService
    {
        private AVAudioPlayer _audioPlayer;

        public Action OnFinishedPlaying { get; set; }

        public void PlayFromUrl(string url)
        {
            Play(url, true);
        }

        public void PlayFromFile(string pathToFile)
        {
            Play(pathToFile, false);
        }

        private void Play(string path, bool fromUrl)
        {
            if (_audioPlayer != null)
            {
                _audioPlayer.FinishedPlaying -= PlayerFinishedPlaying;
                _audioPlayer.Stop();
            }
            var resolvedPath = fromUrl ? NSUrl.FromString(path) : NSUrl.FromFilename(path);
            _audioPlayer = AVAudioPlayer.FromUrl(resolvedPath);
            _audioPlayer.FinishedPlaying += PlayerFinishedPlaying;
            _audioPlayer.Play();
        }

        public void Pause()
        {
            _audioPlayer?.Pause();
        }

        private void PlayerFinishedPlaying(object sender, AVStatusEventArgs eventArgs)
        {
            OnFinishedPlaying?.Invoke();
        }

        public void Play()
        {
            _audioPlayer?.Play();
        }
    }
}