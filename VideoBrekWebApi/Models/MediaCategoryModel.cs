using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoBrekWebApi.Models
{
    [Table("MediaCategory")]
    public class MediaCategoryModel: BaseEntity
    {
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        //public int SeasonTotal { get; set; }
        //public int EpisodeTotal { get; set; }
        //public int DisplayOrder { get; set; }
        public string CreateDtTm { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        //public virtual List<MediaCategoryMediaModel> MediaCategoryMedia { get; set; }
    }
}