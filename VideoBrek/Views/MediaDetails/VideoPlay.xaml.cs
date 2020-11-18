using System.ComponentModel;
using VideoBrek.ViewModels.MRCATabbedPage.MediaDetails;
using Xamarin.Forms;
using static VideoBrek.Models.MediaHandlerModel;

namespace VideoBrek.Views.MediaDetails
{
    [DesignTimeVisible(false)]
    public partial class VideoPlay : ContentPage
    {
        public VideoPlayViewModel vm { get; set; }
        public VideoPlay(AllMediaModel allMediaModel)

        {
            InitializeComponent();
            //CustomNavigationPage.SetBarBackground(this, Color.Green);
            NavigationPage.SetHasNavigationBar(this, false);
           
            base.BindingContext = vm = new VideoPlayViewModel(Navigation);
            vm.SelectedAllMedia = allMediaModel;
            videoPlayer.Source = vm.SelectedAllMedia.AliasCloudUrl;
            //vm.SelectedAllMedia.AliasCloudUrl = "http://vjs.zencdn.net/v/oceans.mp4";

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Send(this, "allowLandScape");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Send(this, "preventLandScape"); //during page close setting back to portrait 
        }



    }
}