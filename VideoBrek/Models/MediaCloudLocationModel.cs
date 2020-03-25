using System.Collections.Generic;

namespace VideoBrek.Models
{
    public class MediaCloudLocationModel
    {
        public int CloudLocationId { get; set; }
        public string CloudLocationName { get; set; }
        public string CloudLocationUrl { get; set; }
        public string CloudLocationIp { get; set; }
        public string CreateDtTm { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public List<MediaModel> Media { get; set; }
    }
}