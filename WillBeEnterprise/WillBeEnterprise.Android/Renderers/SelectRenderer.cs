using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using WillBeEnterprise.Droid.Renderers;
using WillBeEnterprise.Views.Custom;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Select), typeof(SelectRenderer))]
namespace WillBeEnterprise.Droid.Renderers
{
    class SelectRenderer : ButtonRenderer
    {
        private GradientDrawable _gradientBackground;

        public SelectRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> args)
        {
            base.OnElementChanged(args);
            var select = (Select)Element;
            if (select != null)
            {
                Paint(select);
            }

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);
            System.Diagnostics.Debug.Write("Changing select property = " + args.PropertyName);
            if (args.PropertyName.Equals(Select.SelectedProperty.PropertyName))
                Paint((Select)Element);
        }

        private bool ShouldPaint(string propertyName)
        {
            return (propertyName == Select.SelectedStartColorProperty.PropertyName || propertyName == Select.SelectedStartColorProperty.PropertyName) &&
                Element != null;

        }

        private void Paint(Select select)
        {
            if (select.Selected)
            {
                _gradientBackground = new GradientDrawable(GradientDrawable.Orientation.LeftRight,
                    new int[] { select.SelectedStartColor.ToAndroid(), select.SelectedEndColor.ToAndroid() });
                Control.SetTextColor(select.SelectedTextColor.ToAndroid());
            }
            else
            {
                _gradientBackground = new GradientDrawable();
                Control.SetTextColor(select.TextColor.ToAndroid());
            }
            _gradientBackground.SetShape(ShapeType.Rectangle);
            _gradientBackground.SetCornerRadius(select.CornerRadius);
            Control.SetBackground(_gradientBackground);
        }

    }
}