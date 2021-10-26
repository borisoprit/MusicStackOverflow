using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicStackOverflow
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeadProjectAudioPage : ContentPage
    {
        public HeadProjectAudioPage()
        {
            InitializeComponent();

          

            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.PlaybackEnded += (sender,e)=>
{
     btnPlay.IsVisible = true;
     btnpause.IsVisible = false;
};
            player.Load("Diminished.mp3");


            btnPlay.Clicked += BtnPlayClicked;
            btnPause.Clicked += BtnPauseClicked;
            switchLoop.Toggled += SwitchLoopToggled;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            btnPause.IsVisible = false;
        }

        private void SwitchLoopToggled(object sender, ToggledEventArgs e)
        {
            Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current.Loop = switchLoop.IsToggled;
        }

        private void BtnPlayClicked(object sender, EventArgs e)
        {
          // btnPause.IsVisible = true;
           // btnPlay.IsVisible = false;
            Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current.Play();
          
        }
        private void BtnPauseClicked(object sender, EventArgs e)
        {
            btnPlay.IsVisible = true;
            btnPause.IsVisible = false;
            Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current.Pause();
        }

    }
}