using Android.Media;
using Android.Net;
using WillBeEnterprise.Droid.Services;
using WillBeEnterprise.Services.Sound;
using Xamarin.Forms;

[assembly: Dependency(typeof(SoundService))]
namespace WillBeEnterprise.Droid.Services
{

    public class SoundService : ISoundService
    {
        private MediaPlayer _mediaPlayer;

        public void Play()
        {
            var url = "https://archive.org/details/Sample_Audio_Clips_mp3";
            _mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Uri.Parse(url));
            _mediaPlayer.Start();
        }

    }
}