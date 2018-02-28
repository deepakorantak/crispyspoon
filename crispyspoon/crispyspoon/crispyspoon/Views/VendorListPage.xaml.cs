using CrispySpoon.ViewModels;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrispySpoon.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VendorListPage : ContentPage
    {
        VendorViewModel viewModel;
        public ObservableCollection<string> Vendors { get; set; }

        public VendorListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new VendorViewModel();

            VendorListView.ItemsSource = viewModel.Vendors;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //if (viewModel.Vendors.Count == 0)
            viewModel.LoadItemsCommand.Execute(null);
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewVendorPage());
        }
    }
}
