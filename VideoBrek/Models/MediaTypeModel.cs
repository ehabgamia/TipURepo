using System.Collections.Generic;

namespace VideoBrek.Models
{
    public class MediaTypeModel
    {
        public int MediaTypeId { get; set; }
        public string MediaTypeName { get; set; }
        public bool IsActive { get; set; }
        public string CreateDtTm { get; set; }
        public int CreatedBy { get; set; }
        public List<MediaModel> Media { get; set; }
    }
}