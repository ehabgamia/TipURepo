using System.Collections.Generic;

namespace VideoBrek.Models
{
    public class MediaModel
    {
        public int MediaId { get; set; }
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
        public MediaCloudLocationModel CloudLocation { get; set; }
        public MediaTypeModel MediaType { get; set; }
        public List<MediaCategoryMediaModel> MediaCategoryMedia { get; set; }
        public List<UserMyListModel> UserMyList { get; set; }


        public string AliasThumbURL
        {
            //get { return "http://graceanointing.org" + ThumbURL; }
            get { return !string.IsNullOrEmpty(Thumbnail) ? "https://img.youtube.com/vi/" + CloudMediaUrl + "/maxresdefault.jpg" : "https://www.prioritysoftware.com/wp-content/uploads/2015/02/xno-image.png.pagespeed.ic.TALCyIr8tu.webp"; }
        }

        public string AliasCloudUrl
        {
            get { return "https://www.youtube.com/" + CloudMediaUrl; }
        }
    }
}