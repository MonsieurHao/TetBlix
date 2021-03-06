﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TetBlix
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        private Item series;

        public ItemsPage()
        {

            
            BindingContext = viewModel = new ItemsViewModel();
          
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
            
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            series = new Item();
            await Navigation.PushAsync(new NewItemPage(series));
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
            if (viewModel.Items.Count != 0)
            {
                viewModel.LoadItemsCommand.Execute(null);
                ToolbarItems.Clear();
                InitializeComponent();
            }
            
        }
    }
}