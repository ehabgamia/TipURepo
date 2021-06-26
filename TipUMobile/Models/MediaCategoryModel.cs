using System.Collections.Generic;

namespace VideoBrek.Models
{
    public class MediaCategoryModel
    {
        public int CategoryId { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public int SeasonTotal { get; set; }
        public int EpisodeTotal { get; set; }
        public int DisplayOrder { get; set; }
        public string CreateDtTm { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public List<MediaCategoryMediaModel> MediaCategoryMedia { get; set; }
    }
}