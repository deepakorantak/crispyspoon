using CrispySpoon.Views;
using Xamarin.Forms;

namespace CrispySpoon
{
    public partial class App : Application
	{
        public static bool IsUserLoggedIn = false;

        public App ()
		{
			InitializeComponent();
            MainPage = new NavigationPage(new HomePage());
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
