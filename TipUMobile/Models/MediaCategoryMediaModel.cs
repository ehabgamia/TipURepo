namespace VideoBrek.Models
{
    public class MediaCategoryMediaModel
    {
        public int MediaCategoryMediaId { get; set; }
        public int MediaId { get; set; }
        public int MediaCategoryId { get; set; }
        public int SeasonId { get; set; }
        public int EpisodeId { get; set; }
        public int CloudLocationId { get; set; }
        public string CreateDtTm { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public MediaModel Media { get; set; }
        public MediaCategoryModel MediaCategory { get; set; }
    }
}