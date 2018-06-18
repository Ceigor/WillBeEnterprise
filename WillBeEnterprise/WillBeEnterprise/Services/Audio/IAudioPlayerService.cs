using System;

namespace WillBeEnterprise.Services.Audio
{
    public interface IAudioPlayerService
    {
        void Play();
        void PlayFromUrl(string url);
        void PlayFromFile(string pathToFile);
        void Pause();
        Action OnFinishedPlaying { get; set; }
    }
}
