using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoBrekWeb.Models;

namespace VideoBrekWeb.ViewModel
{
    public class MediaListViewModel
    {
        public MediaListViewModel()
        {
            this.mediaList = new List<MediaModel>();
        }
        public List<MediaModel> mediaList { get; set; }
        public MediaModel mediaModel { get; set; }
    }
}