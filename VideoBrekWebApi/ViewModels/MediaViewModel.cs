using System;
using System.Collections.Generic;
using VideoBrekWebApi.Models;

namespace VideoBrekWebApi.ViewModels
{
    public class MediaViewModel
    {
        public int DisplayOrder { get; set; }
        public string CategoryName { get; set; }

        public MediaViewModel()
        {

            this.mediaModelList = new List<MediaModel>();
        }
        public List<MediaModel> mediaModelList { get; set; }
    }
  
}
