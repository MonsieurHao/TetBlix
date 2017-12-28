using System;
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
        private string id;
        private string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public ICommand DeleteShowCommand { get; private set; }


        public Item Item { get; set; }
        public ItemDetailViewModel(Item item)
        {
            Title = item?.Text;
            Item = item;

            DeleteShowCommand = new Command(DeleteShow);

        }

        void DeleteShow()
        {
            Realm context = Realm.GetInstance();
            var series = Item;

            DataStore.DeleteItemAsync(series);
            OnPropertyChanged("series");
            App.Current.MainPage.Navigation.PopAsync();
        }

    }
}
