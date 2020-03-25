using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VideoBrekWebApi.Models
{
    [Table("MediaCategoryMedia")]
    public class MediaCategoryMediaModel
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public int EpisodeId { get; set; }
        public int CloudLocationId { get; set; }
        public string CreateDtTm { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public virtual MediaModel Media { get; set; }
        public int MediaId { get; set; }
        public virtual MediaCategoryModel MediaCategory { get; set; }
        public int MediaCategoryId { get; set; }
    }
}