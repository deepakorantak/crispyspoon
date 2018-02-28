using CrispySpoon.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrispySpoon.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class LoginPage : ContentPage
    {
        LoginViewModel viewModel;
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new LoginViewModel();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new 
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user.Username, user.Password);

            if (isValid)
            {
                App.IsUserLoggedIn = true;

                Navigation.InsertPageBefore(new VendorListPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }
        }

        bool AreCredentialsCorrect(string user, string password)
        {
            return user == Constants.Username && password == Constants.Password;
        }
    }

}