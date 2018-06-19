using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace WillBeEnterprise.Views.Custom
{
    public class Select : Button
    {
        public static readonly BindableProperty SelectedStartColorProperty = BindableProperty.Create(nameof(SelectedStartColor), typeof(Color), typeof(Select), Color.Default);
        public Color SelectedStartColor
        {
            get { return (Color)GetValue(SelectedStartColorProperty); }
            set { SetValue(SelectedStartColorProperty, value); }
        }

        public static readonly BindableProperty SelectedEndColorProperty = BindableProperty.Create(nameof(SelectedEndColor), typeof(Color), typeof(Select), Color.Default);
        public Color SelectedEndColor
        {
            get { return (Color)GetValue(SelectedEndColorProperty); }
            set { SetValue(SelectedEndColorProperty, value); }
        }

        public static readonly BindableProperty SelectedProperty = BindableProperty.Create(nameof(Selected), typeof(bool), typeof(Select), false, BindingMode.TwoWay);
        public bool Selected
        {
            get
            {
                return (bool)GetValue(SelectedProperty);
            }
            set
            {
                SetValue(SelectedProperty, value);
            }
        }

        public static BindableProperty SelectedCommandProperty = BindableProperty.Create(nameof(SelectedCommand), typeof(ICommand), typeof(Select), null);
        public ICommand SelectedCommand
        {
            get
            {
                return (ICommand)GetValue(SelectedCommandProperty);
            }
            set
            {
                SetValue(SelectedCommandProperty, value);
            }
        }

        public static BindableProperty SelectedTextColorProperty = BindableProperty.Create(nameof(SelectedTextColor), typeof(Color), typeof(Select), Color.White);
        public Color SelectedTextColor
        {
            get { return (Color)GetValue(SelectedTextColorProperty); }
            set { SetValue(SelectedTextColorProperty, value); }
        }

        public static BindableProperty SelectedCommandParameterProperty = BindableProperty.Create(nameof(SelectedCommandParameter), typeof(object), typeof(Select), null);
        public object SelectedCommandParameter
        {
            get
            {
                return GetValue(SelectedCommandParameterProperty);
            }
            set
            {
                SetValue(SelectedCommandParameterProperty, value);
            }
        }

        public void ChangeSelect(object sender, EventArgs eventArgs)
        {
            Selected = !Selected;
        }

        public class SelectChangedArgs : EventArgs
        {
            public bool Selected { get; set; }
        }

        public Select()
        {
            Clicked += ChangeSelect;
        }
    }
}
