using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoBrekWeb.Models;

namespace VideoBrekWeb.ViewModel
{
    public class MediaCategoryListViewModel
    {
        public MediaCategoryListViewModel()
        {
            this.mediaCategoryModelList = new List<MediaCategoryModel>();
        }
        public List<MediaCategoryModel> mediaCategoryModelList { get; set; }
        public MediaCategoryModel mediaCategoryModel { get; set; }
    }
}