using CrispySpoon.Data;
using CrispySpoon.Views;
using Xamarin.Forms;

namespace CrispySpoon
{
    public partial class App : Application
	{
        static CrispySpoonDatabase database;
        public static bool IsUserLoggedIn = false;

        public App ()
		{
			InitializeComponent();
            MainPage = new NavigationPage(new HomePage());
        }

        public static CrispySpoonDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new CrispySpoonDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("CrispySpoonDB.db3"));
                }
                return database;
            }
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
