using CrispySpoon.Models;
using CrispySpoon.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrispySpoon.ViewModels
{
    public class VendorViewModel : BaseViewModel
    {
        public ObservableCollection<Vendor> Vendors { get; set; }
        public Command LoadVendorsCommand { get; set; }

        public VendorViewModel()
        {
            Title = "Vendors";
            Vendors = new ObservableCollection<Vendor>();
            LoadVendorsCommand = new Command(async () => await ExecuteLoadVendorsCommand());

            MessagingCenter.Subscribe<NewVendorPage, Vendor>(this, "AddVendor", async (obj, vendor) =>
            {
                var _vendor = vendor as Vendor;
                Vendors.Add(_vendor);
                await App.Database.SaveDataAsync(_vendor);
            });

            MessagingCenter.Subscribe<VendorDetailPage, Vendor>(this, "DeleteVendor", async (obj, vendor) =>
            {
                Vendors.Remove(vendor);
                await App.Database.DeleteDataAsync(vendor);
            });
        }

        async Task ExecuteLoadVendorsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Vendors.Clear();

                IEnumerable<Vendor> vendors = await App.Database.GetDataAsync<Vendor>();

                foreach (var vendor in vendors)
                {
                    Vendors.Add(vendor);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
