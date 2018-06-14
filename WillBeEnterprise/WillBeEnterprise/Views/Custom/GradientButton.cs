using System.Diagnostics;
using Xamarin.Forms;

namespace WillBeEnterprise.Views.Custom
{
    public class GradientButton : Button
    {
        public static readonly BindableProperty StartColorProperty = BindableProperty.Create(nameof(StartColor), typeof(Color), typeof(GradientButton), Color.Default);
        public Color StartColor
        {
            get { return (Color)GetValue(StartColorProperty);}
            set {SetValue(StartColorProperty, value);}
        }
        public static readonly BindableProperty EndColorProperty = BindableProperty.Create(nameof(EndColor), typeof(Color), typeof(GradientButton), Color.Default);
        public Color EndColor
        {
            get { return (Color)GetValue(EndColorProperty);}
            set { SetValue(EndColorProperty, value);}
        }
    }
}
