using CrispySpoon.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrispySpoon.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewVendorPage : ContentPage
	{
        public Vendor Vendor { get; set; }
        public NewVendorPage ()
		{
			InitializeComponent ();

            Vendor = new Vendor
            {
                VendorCode = "AAA",
                VendorName = "New AAA Vendor"
            };

            BindingContext = this;
        }

        async void SaveVendor_Clicked(object sender, EventArgs e)
        {
            var vendor = new Vendor
            {
                VendorCode = this.VendorCode.Text,
                VendorName = this.VendorName.Text
            };
            MessagingCenter.Send(this, "AddVendor", vendor);
            await Navigation.PopAsync();
        }
    }
}