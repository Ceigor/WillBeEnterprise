using CoreAnimation;
using CoreGraphics;
using System.ComponentModel;
using System.Linq;
using UIKit;
using WillBeEnterprise.Views.Custom;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Select), typeof(WillBeEnterprise.iOS.Renderers.SelectRenderer))]
namespace WillBeEnterprise.iOS.Renderers
{
    public class SelectRenderer : ButtonRenderer
    {
        private CAGradientLayer GradientLayer;

        public override CGRect Frame
        {
            get { return base.Frame; }
            set
            {
                if (value.Width > 0 && value.Height > 0)
                {
                    foreach (var layer in Control?.Layer.Sublayers.Where(layer => layer is CAGradientLayer))
                        layer.Frame = new CGRect(0, 0, value.Width, value.Height);
                }
                base.Frame = value;
            }
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
            if (args.PropertyName.Equals(Views.Custom.Select.SelectedProperty.PropertyName))
            {
                Paint((Select)Element);
            }
        }

        private bool ShouldPaint(string propertyName)
        {
            return (propertyName == GradientButton.StartColorProperty.PropertyName || propertyName == GradientButton.EndColorProperty.PropertyName) &&
                Element != null;

        }

        private void Paint(Select select)
        {
            GradientLayer = new CAGradientLayer();
            GradientLayer.CornerRadius = select.CornerRadius;
            if (select.Selected)
            {
                GradientLayer.Colors = new CGColor[] { select.SelectedStartColor.ToUIColor().CGColor, select.SelectedEndColor.ToUIColor().CGColor };
                Control?.SetTitleColor(select.SelectedTextColor.ToUIColor(), UIControlState.Normal);
            }
            else
            {
                GradientLayer.Colors = new CGColor[] { select.BackgroundColor.ToUIColor().CGColor, select.BackgroundColor.ToUIColor().CGColor };
                Control?.SetTitleColor(select.TextColor.ToUIColor(), UIControlState.Normal);
            }
            GradientLayer.StartPoint = new CGPoint(0.0, 0.5);
            GradientLayer.EndPoint = new CGPoint(1.0, 0.5);
            var layer = Control?.Layer.Sublayers.LastOrDefault();
            Control?.Layer.Sublayers?[0].RemoveFromSuperLayer();
            Control?.Layer.InsertSublayer(GradientLayer, 0);
        }
    }
}