using System.Diagnostics;
using WillBeEnterprise.ViewModels;
using WillBeEnterprise.Views;
using WillBeEnterprise.Views.Factory;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WillBeEnterprise
{
    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            var mainView = ViewsFactory.CreateBindedView<MainView, MainViewModel>();
            Debug.WriteLine("MainPage is of type = " + mainView);
            MainPage = new NavigationPage(mainView);
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
