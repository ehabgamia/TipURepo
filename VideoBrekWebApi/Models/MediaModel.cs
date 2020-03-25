using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VideoBrekWebApi.Models
{
    [Table("Media")]
    public class MediaModel
    {
        public int Id { get; set; }
        public int MediaTypeId { get; set; }
        public int CloudLocationId { get; set; }
        public string CloudMediaUrl { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string MediaDesc { get; set; }
        public string SearchTags { get; set; }
        public int? FileSizeMb { get; set; }
        public string Duration { get; set; }
        public string CreateDtTm { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
       
        //public MediaCloudLocationModel CloudLocation { get; set; }
        //public MediaTypeModel MediaType { get; set; }
        //public List<MediaCategoryMediaModel> MediaCategoryMedia { get; set; }
        //public virtual List<UserMyListModel> UserMyList { get; set; }
    }
}