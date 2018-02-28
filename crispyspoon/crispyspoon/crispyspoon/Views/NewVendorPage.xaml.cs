using CrispySpoon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        async void Save_Clicked(object sender, EventArgs e)
        {
            var vendor = new Vendor
            {
                VendorCode = this.VendorCode.Text,
                VendorName = this.VendorName.Text
            };
            await App.Database.SaveVendorAsync(vendor);
            await Navigation.PopAsync();
        }
    }
}