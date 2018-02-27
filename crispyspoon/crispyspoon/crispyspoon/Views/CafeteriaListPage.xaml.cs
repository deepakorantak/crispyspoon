﻿using CrispySpoon.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrispySpoon.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CafeteriaListPage : ContentPage
    {
        CafeteriaViewModel viewModel;
        public ObservableCollection<string> Cafeterias { get; set; }

        public CafeteriaListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new CafeteriaViewModel();

            CafeteriasListView.ItemsSource = viewModel.Cafeterias;
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

            if (viewModel.Cafeterias.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
