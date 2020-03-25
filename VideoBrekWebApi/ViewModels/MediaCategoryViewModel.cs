using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace VideoBrekWebApi.ViewModels
{
    public class MediaCategoryViewModel : BaseEntity
    {
        public int Id { get; set; }
        [DisplayName("Category Code")]
        public string CategoryCode { get; set; }
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        [DisplayName("Season Total")]
        public int SeasonTotal { get; set; }
        [DisplayName("Episode Total")]
        public int EpisodeTotal { get; set; }
        public int DisplayOrder { get; set; }
        public string CreateDtTm { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
