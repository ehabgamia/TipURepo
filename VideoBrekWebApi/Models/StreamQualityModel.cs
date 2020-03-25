using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VideoBrekWebApi.Models
{
    [Table("StreamQuality")]
    public class StreamQualityModel
    {
        public int Id { get; set; }
        public string StreatQualityName { get; set; }
        public bool IsActive { get; set; }
        public string CreatedDtTm { get; set; }
        public int CreatedBy { get; set; }
        public virtual List<UserProfileConfigModel> UserProfileConfig { get; set; }
    }
}