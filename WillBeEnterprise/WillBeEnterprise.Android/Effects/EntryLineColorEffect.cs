using Android.Widget;
using System;
using System.Diagnostics;
using WillBeEnterprise.Behaviors;
using WillBeEnterprise.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(EntryLineColorEffect), nameof(EntryLineColorEffect))]
namespace WillBeEnterprise.Droid.Effects
{
    public class EntryLineColorEffect : PlatformEffect
    {
        private EditText control;

        protected override void OnAttached()
        {
            try
            {
                Debug.WriteLine("At least tring to attach...");
                control = Control as EditText;
                UpdateLineColor();
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        protected override void OnDetached()
        {
            control = null;
        }

        private void UpdateLineColor()
        {
            try
            {
                if (control != null)
                    control.Background.SetColorFilter(LineColorBehavior.GetLineColor(Element).ToAndroid(), Android.Graphics.PorterDuff.Mode.SrcAtop);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}