using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using WillBeEnterprise.Views.Custom;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GradientButton), typeof(WillBeEnterprise.Droid.Renderers.GradientButtonRenderer))]
namespace WillBeEnterprise.Droid.Renderers
{
    public class GradientButtonRenderer : ButtonRenderer
    {

        private GradientDrawable _gradientBackground;

        public GradientButtonRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> args)
        {
            base.OnElementChanged(args);
            var button = (GradientButton)Element;
            if (button != null)
                Paint(button);

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);
            if (ShouldPaint(args.PropertyName))
                Paint((GradientButton)Element);
        }

        private bool ShouldPaint(string propertyName)
        {
            return (propertyName == GradientButton.StartColorProperty.PropertyName || propertyName == GradientButton.EndColorProperty.PropertyName) &&
                Element != null;

        }

        private void Paint(GradientButton gradientButton)
        {
            int[] colors = { gradientButton.StartColor.ToAndroid(), gradientButton.EndColor.ToAndroid() };
            _gradientBackground = new GradientDrawable(GradientDrawable.Orientation.LeftRight, colors);
            _gradientBackground.SetShape(ShapeType.Rectangle);
            _gradientBackground.SetCornerRadius(gradientButton.CornerRadius);
            Control.SetBackground(_gradientBackground);
        }

    }
}