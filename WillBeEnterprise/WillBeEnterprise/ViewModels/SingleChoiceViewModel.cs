using System.Threading.Tasks;
using System.Windows.Input;
using WillBeEnterprise.Models;
using WillBeEnterprise.ViewModels.Base;
using WillBeEnterprise.Views;
using Xamarin.Forms;

namespace WillBeEnterprise.ViewModels
{
    public class SingleChoiceViewModel : ChoiceViewModel<string>
    {
        public ICommand NextPageCommand { get; private set; }

        public SingleChoiceViewModel() : base(new StringSelectable[] { new StringSelectable("Ten minutes"), new StringSelectable("Fifteen minutes"), new StringSelectable("Twenty minutes") })
        {
            FirstChangedCommand = new Command(() => { FirstSelected = !FirstSelected; UnselectSelected(UnselectionException.First); NextPageEnabled = IsAnythingSelected(); });
            SecondChangedCommand = new Command(() => { SecondSelected = !SecondSelected; UnselectSelected(UnselectionException.Second); NextPageEnabled = IsAnythingSelected(); });
            ThirthChangedCommand = new Command(() => { ThirthSelected = !ThirthSelected; UnselectSelected(UnselectionException.Thirth); NextPageEnabled = IsAnythingSelected(); });
            ForthChangedCommand = new Command(() => { ForthSelected = !ForthSelected; UnselectSelected(UnselectionException.Forth); NextPageEnabled = IsAnythingSelected(); });
            NextPageCommand = new Command(async () => await GoToNextPage());
        }
        
        private void UnselectSelected(UnselectionException exception)
        {
            if (FirstSelected && exception != UnselectionException.First)
            {
                FirstSelected = false;
            }
            if (SecondSelected && exception != UnselectionException.Second)
            {
                SecondSelected = false;
            }
            if (ThirthSelected && exception != UnselectionException.Thirth)
            {
                ThirthSelected = false;
            }
            if (ForthSelected && exception != UnselectionException.Forth)
            {
                ForthSelected = false;
            }
        }

        private async Task GoToNextPage()
        {
            if(IsAnythingSelected())
            {
                await navigationService.NavigateToAsync<MasteryView, MasteryViewModel>();
            }
        }

        public enum UnselectionException
        {
            First, Second, Thirth, Forth
        }
    }
}
