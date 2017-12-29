using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TetBlix
{

    public class ItemsViewModel : BaseViewModel
    {
        public System.Collections.ObjectModel.ObservableCollection<Item> _items;

        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged("Items"); }
        }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "TETBLIX";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(execute: async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Item;
                await DataStore.AddItemAsync(_item);
                Items.Add(_item);
                System.Diagnostics.Debug.WriteLine(" : {0} ", Items.Count);
            });
        }
        

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync();
                foreach (var item in items)
                {
                    Items.Add(item);
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

            System.Diagnostics.Debug.WriteLine("ExecuteLoadItemsCommand : {0} " ,Items.Count);
        }
    }
}
