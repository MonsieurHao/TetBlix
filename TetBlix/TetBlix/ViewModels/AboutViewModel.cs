using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace TetBlix
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://bttravel.sytes.net/")));
        }

        public ICommand OpenWebCommand { get; }
    }
}