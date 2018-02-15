using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace crispyspoon.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
    {
		public MainPage ()
		{
			InitializeComponent ();
		}

        async void OnLogout_Clicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }
    }
}