using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MusicStackOverflow
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnLibrary.Clicked += (s, e) => Navigation.PushAsync(new LibraryAudioPage());
            btnLocal.Clicked += (s, e) => Navigation.PushAsync(new HeadProjectAudioPage());
        }
    }
}
