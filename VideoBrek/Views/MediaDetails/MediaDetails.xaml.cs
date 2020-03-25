using System;
using System.Linq;
using System.Threading.Tasks;
using VideoBrek.Models;
using VideoBrek.PCL.Common;
using VideoBrek.ViewModels.Explore;
using Xamarin.Forms;
using YoutubeExplode;
using YoutubeExplode.Models;
using YoutubeExplode.Models.MediaStreams;
using static VideoBrek.Models.MediaHandlerModel;

namespace VideoBrek.Views.MediaDetails
{
    public partial class MediaDetails : ContentPage
    {
        public MediaDetailsViewModel vm { get; set; }
        public MediaDetails(AllMediaModel getMediasModel)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            base.BindingContext = vm = new MediaDetailsViewModel(Navigation);
            vm.SelectedAllMedia = getMediasModel;

            vm.AddToMyListIconSource = (!MediaHandlerModel.MyDataSourceAll.SelectMany(a => a.Media).ToList().Where(p => p.Id == vm.SelectedAllMedia.Id).FirstOrDefault().IsAddedToMyList) ? "ic_AddToMyList.png" : "ic_AddedToMyList.png";
            vm.AddToMyListIconText = (!MediaHandlerModel.MyDataSourceAll.SelectMany(a => a.Media).ToList().Where(p => p.Id == vm.SelectedAllMedia.Id).FirstOrDefault().IsAddedToMyList) ? "Save" : "Saved";
            //if (GlobalConstant.MyListIds != null)
            //{
            //    vm.AddToMyListIconSource = (!GlobalConstant.MyListIds.Contains(getMediasModel.Id)) ? "ic_AddToMyList.png" : "ic_AddedToMyList.png";
            //    vm.AddToMyListIconText = (!GlobalConstant.MyListIds.Contains(getMediasModel.Id)) ? "Save" : "Saved";
            //}
            //else
            //{
            //    vm.AddToMyListIconSource = "ic_AddToMyList.png";
            //    vm.AddToMyListIconText = "Save";
            //}

        }


        async void VideoPlay_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new VideoPlay(vm.SelectedAllMedia));
        }

        
    }
}
