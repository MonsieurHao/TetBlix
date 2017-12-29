using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TetBlix
{
    
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        

        public NewItemPage(Item series)
        {
            Item = series;
            

            if (series.Text == null && series.Description == null) {

                series.Text = "Item name";
                series.Description = "This is an item description.";
                series.Id = Guid.NewGuid().ToString();
            }
            InitializeComponent();
            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", args: Item);
            await Navigation.PopToRootAsync();
        }
    }
}
