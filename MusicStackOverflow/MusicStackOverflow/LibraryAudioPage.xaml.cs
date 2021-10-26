using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicStackOverflow
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LibraryAudioPage : ContentPage
    {
        ISimpleAudioPlayer player;
        public LibraryAudioPage()
        {
            InitializeComponent();

            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;

            player.Load("Diminished.mp3");

            btnPlay.Clicked += BtnPlayClicked;
            btnPause.Clicked += BtnPauseClicked;
            btnStop.Clicked += BtnStopClicked;
          
        }

        private void BtnStopClicked(object sender, EventArgs e)
        {
            Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current.Stop();
        }

        private void BtnPauseClicked(object sender, EventArgs e)
        {
            Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current.Pause();
        }

        private void BtnPlayClicked(object sender, EventArgs e)
        {


            Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current.Play();
        }

        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            var stream = assembly.GetManifestResourceStream("SAPlayerSample." + filename);

            return stream;
        }
    }
}