using CrispySpoon.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrispySpoon.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VendorDetailPage : ContentPage
	{
        public Vendor Vendor { get; set; }
        public VendorDetailPage ()
		{
			InitializeComponent ();
		}

        async void DeleteVendor_Clicked(object sender, EventArgs e)
        {
            var vendor = (Vendor)BindingContext;
            MessagingCenter.Send(this, "DeleteVendor", vendor);
            await Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.Vendor = (Vendor)BindingContext;
        }
    }
}