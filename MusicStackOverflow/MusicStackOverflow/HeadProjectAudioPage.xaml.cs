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

            picker.SelectedItem = "running.mp3"; ///////// You must selected before start if not a error


            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.PlaybackEnded += (sender,e)=>
{
     btnPlay.IsVisible = true;
     btnPause.IsVisible = false;
};
            //   player.Load("running.mp3"); //// change this to picker
            player.Load(picker.SelectedItem.ToString());


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
            btnPause.IsVisible = true;
            btnPlay.IsVisible = false;
            Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current.Play();
          
        }
        private void BtnPauseClicked(object sender, EventArgs e)
        {
            btnPlay.IsVisible = true;
            btnPause.IsVisible = false;
            Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current.Pause();
        }

        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(picker.SelectedItem.ToString());
        }
    }
}