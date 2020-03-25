using System;
using System.Collections.Generic;

namespace VideoBrekWebApi.ViewModels
{
    public class MediaCategoryListModel: BaseEntity
    {
        public MediaCategoryListModel()
        {
            this.mediaCategoryViewModelList = new List<MediaCategoryViewModel>();
        }
        public List<MediaCategoryViewModel> mediaCategoryViewModelList { get; set; }
        public MediaCategoryViewModel MediaCategoryViewModel { get; set; }
    }
}
