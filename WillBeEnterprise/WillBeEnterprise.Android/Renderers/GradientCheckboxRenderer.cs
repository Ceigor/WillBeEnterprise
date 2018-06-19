using Android.Widget;
using Xamarin.Forms.Platform.Android;
using WillBeEnterprise.Views.Custom;
using Android.Support.V7.Widget;
using Xamarin.Forms;
using WillBeEnterprise.Droid.Renderers;
using Android.Content;
using Android.Graphics.Drawables;
using System.ComponentModel;
using Android.Content.Res;

[assembly: ExportRenderer(typeof(GradientCheckBox), typeof(GradientCheckBoxRenderer))]
namespace WillBeEnterprise.Droid.Renderers
{
    public class GradientCheckBoxRenderer : ViewRenderer<GradientCheckBox, AppCompatCheckBox>, CompoundButton.IOnCheckedChangeListener
    {
        private const int DEFAULT_SIZE = 28;
        private const int DEFAULT_PADDING = 16;
        private const int DEFAULT_PADDING_RIGHT = 32;
        private GradientDrawable _gradientBackground;

        public GradientCheckBoxRenderer(Context context) : base(context)
        {

        }

        public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
        {
            ((IViewController)Element).SetValueFromRenderer(GradientCheckBox.IsCheckedProperty, isChecked);
            Element.CheckedCommand?.Execute(Element.CheckedCommandParameter);
        }

        public override SizeRequest GetDesiredSize(int widthConstraint, int heightConstraint)
        {
            var sizeConstraint = base.GetDesiredSize(widthConstraint, heightConstraint);
            if (sizeConstraint.Request.Width == 0)
            {
                var width = widthConstraint;
                if (widthConstraint <= 0)
                {
                    System.Diagnostics.Debug.WriteLine("Default values!");
                    width = DEFAULT_SIZE;
                }
                else if (widthConstraint <= 0)
                {
                    width = DEFAULT_SIZE;
                }
                sizeConstraint = new SizeRequest(new Size(width, sizeConstraint.Request.Height),
                new Size(width, sizeConstraint.Minimum.Height));
            }
            return sizeConstraint;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<GradientCheckBox> eventArgs)
        {
            base.OnElementChanged(eventArgs);
            if (eventArgs.NewElement == null)
                return;
            if (Control == null)
            {
                var checkBox = CreateCheckBox();
                checkBox.SetOnCheckedChangeListener(this);
                SetNativeControl(checkBox);
            }
            Control.Checked = eventArgs.NewElement.Checked;
            Paint(Element as GradientCheckBox);
        }

        private AppCompatCheckBox CreateCheckBox()
        {
            var checkBox = new AppCompatCheckBox(Context);
            var gradientCheckBox = Element as GradientCheckBox;
            checkBox.Text = gradientCheckBox.Text;
            checkBox.TextSize = (float)gradientCheckBox.FontSize;
            checkBox.SetPadding(DEFAULT_PADDING, DEFAULT_PADDING, DEFAULT_PADDING_RIGHT, DEFAULT_PADDING);
            return checkBox;
        }

        private void Paint(GradientCheckBox GradientCheckBox)
        {
            if (Control.Checked)
            {
                int[] colors = { GradientCheckBox.CheckedBackgroundStartColor.ToAndroid(), GradientCheckBox.CheckedBackgroundEndColor.ToAndroid() };
                _gradientBackground = new GradientDrawable(GradientDrawable.Orientation.LeftRight, colors);
                Control.SetTextColor(GradientCheckBox.CheckedTextColor.ToAndroid());
            }
            else
            {
                _gradientBackground = new GradientDrawable();
                Control.SetTextColor(GradientCheckBox.TextColor.ToAndroid());
            }
            _gradientBackground.SetShape(ShapeType.Rectangle);
            _gradientBackground.SetCornerRadius(GradientCheckBox.CornerRadius);
            Control.SetBackground(_gradientBackground);

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs eventArgs)
        {
            base.OnElementPropertyChanged(sender, eventArgs);
            System.Diagnostics.Debug.WriteLine("Changing element property of name = " + eventArgs.PropertyName);
            if (eventArgs.PropertyName == nameof(Element.Checked))
            {
                Control.Checked = Element.Checked;
                Paint(Element as GradientCheckBox);
            }
            else
            {
                //TODO figure this out
                //var checkColors = GetBackgroundColorStateList(Element.CheckColor);
                //Control.SupportButtonTintList = checkColors;
                //Control.BackgroundTintList = GetBackgroundColorStateList(Element.InnerColor);
                //Control.ForegroundTintList = GetBackgroundColorStateList(Element.OutlineColor);
            }
        }

        private ColorStateList GetBackgroundColorStateList(Color color)
        {
            return new ColorStateList(
            new[] 
            {
                new[] { Android.Resource.Attribute.StateEnabled },
                new[] {Android.Resource.Attribute.StateChecked },
                new[] { Android.Resource.Attribute.StateChecked}
            },
            new int[]
            {
                color.WithSaturation(0.1).ToAndroid(),
                color.ToAndroid(),
                color.ToAndroid()
            });
        }

        private void CheckBoxCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs eventArgs)
        {
            Element.Checked = eventArgs.IsChecked;
        }
    }
}