using WillBeEnterprise.Models;
using WillBeEnterprise.ViewModels.Base;
using Microcharts;
using SkiaSharp;
using System.Collections.Generic;

namespace WillBeEnterprise.ViewModels
{
    public class ChartsViewModel : BaseViewModel
    {
        private Mastery _mastery;
        private Chart _masteryChart;
        public Chart MasteryChart
        {
            get { return _masteryChart; }
            set
            {
                _masteryChart = value;
                RaisePropertyChanged(() => MasteryChart);
            }
        }

        private static readonly SKColor AccentColor = SKColor.Parse("#2C5DF9");
        private static readonly SKColor ListeningColor = SKColor.Parse("#4286f4");
        private static readonly SKColor SpeakingColor = SKColor.Parse("#66a0ff");
        private static readonly SKColor ReadingColor = SKColor.Parse("#8a22f9");
        private static readonly SKColor WritingColor = SKColor.Parse("#9b4bf2");
        private static readonly SKColor OrangeColor = SKColor.Parse("#FFD45F");

        public ChartsViewModel()
        {
            _mastery = new Mastery(50, 20, 30, 60);
            SetChart();
        }

        private void SetChart()
        {
            MasteryChart = new LineChart()
            {
                Entries = GetEntries(),
                LineMode = LineMode.Straight,
                PointMode = PointMode.Square,
                LineSize = 8,
                BackgroundColor = SKColors.Transparent,
                LabelTextSize = 30
            };
        }

        private List<Entry> GetEntries()
        {
            return new List<Entry>()
            {
                new Entry(_mastery.Listening){Label = "Listening", ValueLabel = _mastery.Listening.ToString(), Color = ListeningColor, TextColor = AccentColor},
                new Entry(_mastery.Speaking){Label = "Speaking", ValueLabel = _mastery.Speaking.ToString(), Color = SpeakingColor, TextColor = AccentColor},
                new Entry(_mastery.Reading){Label = "Reading", ValueLabel = _mastery.Reading.ToString(), Color = ReadingColor, TextColor = AccentColor},
                new Entry(_mastery.Writing){Label = "Writing", ValueLabel = _mastery.Writing.ToString(), Color = WritingColor, TextColor = AccentColor}
            };
        }
    }
}

