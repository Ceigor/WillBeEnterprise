using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace WillBeEnterprise.Views.Custom
{
    public class GradientCheckBox : Button
    {
        public event EventHandler OnCheckChanged;

        public static readonly BindableProperty CheckedBackgroundStartColorProperty = BindableProperty.Create(nameof(CheckedBackgroundStartColor), typeof(Color), typeof(GradientCheckBox), Color.Default);
        public Color CheckedBackgroundStartColor
        {
            get { return (Color)GetValue(CheckedBackgroundStartColorProperty); }
            set { SetValue(CheckedBackgroundStartColorProperty, value); }
        }
        public static readonly BindableProperty CheckedBackgroundEndColorProperty = BindableProperty.Create(nameof(CheckedBackgroundEndColor), typeof(Color), typeof(GradientCheckBox), Color.Default);
        public Color CheckedBackgroundEndColor
        {
            get { return (Color)GetValue(CheckedBackgroundEndColorProperty); }
            set { SetValue(CheckedBackgroundEndColorProperty, value); }
        }
        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(nameof(Checked), typeof(bool), typeof(GradientCheckBox), false, BindingMode.TwoWay);
        public bool Checked
        {
            get
            {
                return (bool)GetValue(IsCheckedProperty);
            }
            set
            {
                SetValue(IsCheckedProperty, value);
            }
        }
        public static BindableProperty CheckedCommandParameterProperty = BindableProperty.Create(nameof(CheckedCommandParameter), typeof(object), typeof(GradientCheckBox), null);
        public object CheckedCommandParameter
        {
            get
            {
                return GetValue(CheckedCommandParameterProperty);
            }
            set
            {
                SetValue(CheckedCommandParameterProperty, value);
            }
        }
        public static BindableProperty OutlineColorProperty = BindableProperty.Create(nameof(OutlineColor), typeof(Color), typeof(GradientCheckBox), Color.Black);
        public Color OutlineColor
        {
            get { return (Color)GetValue(OutlineColorProperty); }
            set { SetValue(OutlineColorProperty, value); }
        }
        public static BindableProperty InnerColorProperty = BindableProperty.Create(nameof(InnerColor), typeof(Color), typeof(GradientCheckBox), Color.White);
        public Color InnerColor
        {
            get { return (Color)GetValue(InnerColorProperty); }
            set { SetValue(InnerColorProperty, value); }
        }
        public static BindableProperty CheckColorProperty = BindableProperty.Create(nameof(CheckColor), typeof(Color), typeof(GradientCheckBox), Color.Black);
        public Color CheckColor
        {
            get { return (Color)GetValue(CheckColorProperty); }
            set { SetValue(CheckColorProperty, value); }
        }
        public static BindableProperty CheckedOutlineColorProperty = BindableProperty.Create(nameof(CheckedOutlineColor), typeof(Color), typeof(GradientCheckBox), Color.Black);
        public Color CheckedOutlineColor
        {
            get { return (Color)GetValue(CheckedOutlineColorProperty); }
            set { SetValue(CheckedOutlineColorProperty, value); }
        }
        public static BindableProperty CheckedInnerColorProperty = BindableProperty.Create(nameof(CheckedInnerColor), typeof(Color), typeof(GradientCheckBox), Color.White);
        public Color CheckedInnerColor
        {
            get { return (Color)GetValue(CheckedInnerColorProperty); }
            set { SetValue(CheckedInnerColorProperty, value); }
        }
        public static BindableProperty CheckedTextColorProperty = BindableProperty.Create(nameof(CheckedInnerColor), typeof(Color), typeof(GradientCheckBox), Color.White);
        public Color CheckedTextColor
        {
            get { return (Color)GetValue(CheckedTextColorProperty); }
            set { SetValue(CheckedTextColorProperty, value); }
        }
        public static BindableProperty CheckedCommandProperty = BindableProperty.Create(nameof(CheckedCommand), typeof(ICommand), typeof(GradientCheckBox), null);
        public ICommand CheckedCommand
        {
            get
            {
                return (ICommand)GetValue(CheckedCommandProperty);
            }
            set
            {
                SetValue(CheckedCommandProperty, value);
            }
        }

        public void FireCheckChange()
        {
            OnCheckChanged?.Invoke(this, new CheckChangedArgs
            {
                Checked = Checked
            });
        }

        public class CheckChangedArgs : EventArgs
        {
            public bool Checked { get; set; }
        }
    }
}
