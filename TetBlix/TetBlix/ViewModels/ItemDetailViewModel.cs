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
        public ICommand DeleteShowCommand { get; private set; }
        private string _seriesId;

        public void SeriesDetailsViewModel(string seriesId)
        {
            _seriesId = seriesId;
            Realm context = Realm.GetInstance();
            var series = context.Find<Item>(seriesId);

            Text = series.Text;
            Description = series.Description;

            DeleteShowCommand = new Command(DeleteShow);
            

        }

        void DeleteShow()
        {
            Realm context = Realm.GetInstance();
            var series = context.Find<Item>(_seriesId);

            context.Write(() =>
            {
                context.Remove(series);
            });
            App.Current.MainPage.Navigation.PopAsync();
        }



        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
