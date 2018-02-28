using CrispySpoon.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrispySpoon.ViewModels
{
    public class VendorViewModel : BaseViewModel
    {
        public ObservableCollection<Vendor> Vendors { get; set; }
        public Command LoadItemsCommand { get; set; }

        public VendorViewModel()
        {
            Title = "Vendors";
            Vendors = new ObservableCollection<Vendor>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadVendorCommand());
        }

        async Task ExecuteLoadVendorCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Vendors.Clear();
                IEnumerable<Vendor> vendors;

                vendors = await App.Database.GetItemsAsync();

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
