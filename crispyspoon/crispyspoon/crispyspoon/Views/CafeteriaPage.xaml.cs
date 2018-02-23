using crispyspoon.Models;
using crispyspoon.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace crispyspoon.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CafeteriaPage : ContentPage
    {
        public ObservableCollection<Item> Cafeterias { get; set; }
        CafeteriasViewModel viewModel;

        public CafeteriaPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new CafeteriasViewModel();

            Cafeterias = viewModel.Items;

            MyListView.ItemsSource = Cafeterias;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
