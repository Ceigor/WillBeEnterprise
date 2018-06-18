using Android.Media;
using System;
using WillBeEnterprise.Droid.Services;
using WillBeEnterprise.Services.Audio;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioPlayerService))]
namespace WillBeEnterprise.Droid.Services
{

    public class AudioPlayerService : IAudioPlayerService
    {
        private MediaPlayer _mediaPlayer;

        public Action OnFinishedPlaying { get; set; }

        private void Play(string path, bool fromFile)
        {
            if (_mediaPlayer != null)
            {
                _mediaPlayer.Completion -= MediaPlayerCompletion;
                _mediaPlayer.Stop();
            }
            SetMediaPlayer(path, fromFile);
            _mediaPlayer.PrepareAsync();
        }

        private void SetMediaPlayer(string path, bool fromFile)
        {
            if (_mediaPlayer != null)
                return;
            _mediaPlayer = new MediaPlayer();
            _mediaPlayer.Prepared += (sender, args) =>
            {
                _mediaPlayer.Start();
                _mediaPlayer.Completion += MediaPlayerCompletion;
            };
            _mediaPlayer.Reset();
            _mediaPlayer.SetVolume(1.0f, 1.0f);
            if (fromFile)
            {
                Android.Content.Res.AssetFileDescriptor assetFileDescriptor = GetAssetFileDescriptor(path);
                if (assetFileDescriptor == null)
                    return;
                _mediaPlayer.SetDataSource(assetFileDescriptor.FileDescriptor, assetFileDescriptor.StartOffset, assetFileDescriptor.Length);
            }
            else
                _mediaPlayer.SetDataSource(Android.App.Application.Context, Android.Net.Uri.Parse(path));
        }

        private Android.Content.Res.AssetFileDescriptor GetAssetFileDescriptor(string path)
        {
            try
            {
                return Android.App.Application.Context.Assets.OpenFd(path);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
        }

        public void PlayFromUrl(string url)
        {
            Play(url, false);
        }

        public void PlayFromFile(string pathToFile)
        {
            Play(pathToFile, true);
        }

        public void Play()
        {
            _mediaPlayer?.Start();
        }

        public void Pause()
        {
            _mediaPlayer?.Pause();
        }

        private void MediaPlayerCompletion(object sender, EventArgs eventArgs)
        {
            OnFinishedPlaying?.Invoke();
        }

    }
}