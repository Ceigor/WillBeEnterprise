using System.Threading.Tasks;
using System.Windows.Input;
using WillBeEnterprise.Models;
using WillBeEnterprise.ViewModels.Base;
using WillBeEnterprise.Views;
using Xamarin.Forms;

namespace WillBeEnterprise.ViewModels
{
    public class MultipleChoiceViewModel : ChoiceViewModel<string>
    {
        public ICommand NextSingleChoicePageCommand { get; private set; }
        public ICommand NextMultipleChoicePageCommand { get; private set; }
        public ICommand NextPageCommand { get; private set; }

        public MultipleChoiceViewModel() : base(new StringSelectable[] { new StringSelectable("Customer Service"), new StringSelectable("Software Development"), new StringSelectable("Sales & Marketing"), new StringSelectable("Forth") })
        {
            FirstChangedCommand = new Command(() => { FirstSelected = !FirstSelected; NextPageEnabled = IsAnythingSelected(); });
            SecondChangedCommand = new Command(() => { SecondSelected = !SecondSelected; NextPageEnabled = IsAnythingSelected(); });
            ThirthChangedCommand = new Command(() => { ThirthSelected = !ThirthSelected; NextPageEnabled = IsAnythingSelected(); });
            ForthChangedCommand = new Command(() => { ForthSelected = !ForthSelected; NextPageEnabled = IsAnythingSelected(); });
            NextPageCommand = new Command(async () => await GoToNextPage());
            NextSingleChoicePageCommand = new Command(async () => await GoToNextSingleChoicePage());
        }

        private async Task GoToNextPage()
        {
            
        }

        private async Task GoToNextSingleChoicePage()
        {
            if (IsAnythingSelected())
            {
                await navigationService.NavigateToAsync<SetYourGoalSingleChoiceView, SingleChoiceViewModel>();
            }
        }
    }
}
