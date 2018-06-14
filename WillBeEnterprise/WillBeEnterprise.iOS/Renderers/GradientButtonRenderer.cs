using CoreAnimation;
using CoreGraphics;
using System.ComponentModel;
using System.Linq;
using UIKit;
using WillBeEnterprise.Views.Custom;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GradientButton), typeof(WillBeEnterprise.iOS.Renderers.GradientButtonRenderer))]
namespace WillBeEnterprise.iOS.Renderers
{
    public class GradientButtonRenderer : ButtonRenderer
    {
        public override CGRect Frame
        {
            get
            {
                return base.Frame;
            }
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
            var gradient = new CAGradientLayer();
            gradient.CornerRadius = gradientButton.CornerRadius;
            gradient.Colors = new CGColor[] { gradientButton.StartColor.ToUIColor().CGColor, gradientButton.EndColor.ToUIColor().CGColor};
            var layer = Control?.Layer.Sublayers.LastOrDefault();
            Control?.Layer.InsertSublayerBelow(gradient, layer);
        }
    }
}