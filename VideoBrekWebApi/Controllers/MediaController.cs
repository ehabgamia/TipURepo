using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using VideoBrekWebApi.Models;
using VideoBrekWebApi.ViewModels;

namespace VideoBrekWebApi.Controllers
{
    public class MediaController : ApiController
    {
        public async Task<VideoAppResult> GetMediaList()
        {
            try
            {
                var _mediaList = new MediaViewModel();

                _mediaList.DisplayOrder = 1;
                _mediaList.CategoryName ="Carousel";

                var _MediaModel = new MediaModel
                {
                    CloudMediaUrl = "https://www.youtube.com/watch?v=rtOvBOTyX00&list=RDrtOvBOTyX00&start_radio=1",
                    Title = "Test1",
                    Thumbnail = "https://img.evbuc.com/https%3A%2F%2Fcdn.evbuc.com%2Fimages%2F62977816%2F6719790553%2F1%2Foriginal.png?h=200&w=450&auto=compress&s=a68b19e86a65f13313de6f816694c2a6"
                };
                _mediaList.mediaModelList.Add(_MediaModel);
                var _MediaModel1 = new MediaModel
                {
                    CloudMediaUrl = "https://www.youtube.com/watch?v=rtOvBOTyX00&list=RDrtOvBOTyX00&start_radio=1",
                    Title = "Test1",
                    Thumbnail = "https://img.evbuc.com/https%3A%2F%2Fcdn.evbuc.com%2Fimages%2F62977816%2F6719790553%2F1%2Foriginal.png?h=200&w=450&auto=compress&s=a68b19e86a65f13313de6f816694c2a6"
                };
                _mediaList.mediaModelList.Add(_MediaModel1);
                var _MediaModel2 = new MediaModel
                {
                    CloudMediaUrl = "https://www.youtube.com/watch?v=rtOvBOTyX00&list=RDrtOvBOTyX00&start_radio=1",
                    Title = "Test1",
                    Thumbnail = "https://img.evbuc.com/https%3A%2F%2Fcdn.evbuc.com%2Fimages%2F62977816%2F6719790553%2F1%2Foriginal.png?h=200&w=450&auto=compress&s=a68b19e86a65f13313de6f816694c2a6"
                };
                _mediaList.mediaModelList.Add(_MediaModel2);
                var _MediaModel3 = new MediaModel
                {
                    CloudMediaUrl = "https://www.youtube.com/watch?v=rtOvBOTyX00&list=RDrtOvBOTyX00&start_radio=1",
                    Title = "Test1",
                    Thumbnail = "https://img.evbuc.com/https%3A%2F%2Fcdn.evbuc.com%2Fimages%2F62977816%2F6719790553%2F1%2Foriginal.png?h=200&w=450&auto=compress&s=a68b19e86a65f13313de6f816694c2a6"
                };
                _mediaList.mediaModelList.Add(_MediaModel3);

                return new VideoAppResult { Message = "Media List", Status = 1, Response = _mediaList };
            }
            catch (Exception ex)
            {
                return new VideoAppResult { Message = ex.ToString(), Status = 0, Response = null };
            }
        }



    }
}
