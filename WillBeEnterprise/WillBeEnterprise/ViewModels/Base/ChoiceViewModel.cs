using System.Windows.Input;
using WillBeEnterprise.Models;

namespace WillBeEnterprise.ViewModels.Base
{
    public abstract class ChoiceViewModel<T> : BaseViewModel
    {
        public ISelectable<T>[] Selectables { get; private set; }
        public ICommand FirstChangedCommand { get; set; }
        public ICommand SecondChangedCommand { get; set; }
        public ICommand ThirthChangedCommand { get; set; }
        public ICommand ForthChangedCommand { get;  set; }
        private bool _nextPageEnabled;
        public bool NextPageEnabled
        {
            get { return _nextPageEnabled; }
            set
            {
                _nextPageEnabled = value;
                RaisePropertyChanged(() => NextPageEnabled);
            }
        }

        public bool FirstSelected
        {
            get { return IsSelected(0); }
            set
            {
                ChangeSelection(0, value);
                RaisePropertyChanged(() => FirstSelected);
            }
        }

        public bool SecondSelected
        {
            get { return IsSelected(1); }
            set
            {
                ChangeSelection(1, value);
                RaisePropertyChanged(() => SecondSelected);
            }
        }

        public bool ThirthSelected
        {
            get { return IsSelected(2); }
            set
            {
                ChangeSelection(2, value);
                RaisePropertyChanged(() => ThirthSelected);
            }
        }

        public bool ForthSelected
        {
            get { return IsSelected(3); }
            set
            {
                ChangeSelection(3, value);
                RaisePropertyChanged(() => ForthSelected);
            }
        }

        public ChoiceViewModel(ISelectable<T>[] selectables)
        {
            Selectables = selectables;
        }

        public bool IsAnythingSelected()
        {
            foreach (var selectable in Selectables)
            {
                if (selectable.Selected)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsSelected(int index)
        {
            if(index >= Selectables.Length)
            {
                return false;
            }
            return Selectables[index].Selected;
        }

        private void ChangeSelection(int index, bool value)
        {
            if(index >= Selectables.Length)
            {
                return;
            }
            Selectables[index].Selected = value;
        }
    }
}
