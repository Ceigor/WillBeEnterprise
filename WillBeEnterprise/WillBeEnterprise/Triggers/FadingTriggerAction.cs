using Xamarin.Forms;

namespace WillBeEnterprise.Triggers
{
    public class FadingTriggerAction : TriggerAction<VisualElement>
    {
        public double Scale { get; set; }
        public uint Length { get; set; }
        public double Opacity { get; set; }

        public FadingTriggerAction()
        {
            Scale = 0.5;
            Length = 500;
            Opacity = 0.1;
        }

        protected override async void Invoke(VisualElement visual)
        {
            await visual.FadeTo(Opacity, Length / 4, Easing.SinOut);
            await visual.ScaleTo(Scale, Length / 4, Easing.SinOut);
            await visual.ScaleTo(1, Length / 4, Easing.SinIn);
            await visual.FadeTo(1, Length / 4, Easing.SinOut);
        }
    }
}
