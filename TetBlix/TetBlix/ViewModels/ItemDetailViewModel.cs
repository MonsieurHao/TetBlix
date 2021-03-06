﻿using System;
using Realms;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;




namespace TetBlix
{
    public class ItemDetailViewModel : BaseViewModel
    {
        private string text;
        public string Text
        {
            get { return text; }
            set { text = value;
                OnPropertyChanged("Text");
            }
        }
        private string desc;
        public string Description
        {
            get { return desc; }
            set
            {
                desc = value;
                OnPropertyChanged("Description");
            }
        }

        public ICommand DeleteShowCommand { get; private set; }

        public ICommand UpdateShowCommand { get; private set; }


        public Item Item { get; set; }
        public ItemDetailViewModel(Item item)
        {
            Title = item?.Text;
            Item = item;

            UpdateShowCommand = new Command(UpdateShow);
            DeleteShowCommand = new Command(DeleteShow);

        }

        async void DeleteShow()
        {
            var series = Item;

            await DataStore.DeleteItemAsync(series);
            await App.Current.MainPage.Navigation.PopAsync();
        }

        async void UpdateShow()
        {
            var series = Item;
            await App.Current.MainPage.Navigation.PushAsync(new NewItemPage(series));

        }

    }
}
