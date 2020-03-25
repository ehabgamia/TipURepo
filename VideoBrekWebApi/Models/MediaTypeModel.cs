using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoBrekWebApi.Models
{
    [Table("MediaType")]
    public class MediaTypeModel
    {
        public int Id { get; set; }
        public string MediaTypeName { get; set; }
        public bool IsActive { get; set; }
        public string CreateDtTm { get; set; }
        public int CreatedBy { get; set; }
        public virtual List<MediaModel> Media { get; set; }
    }
}