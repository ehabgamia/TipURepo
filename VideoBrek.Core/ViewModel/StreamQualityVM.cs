using System;
using System.Collections.Generic;
using System.Text;

namespace VideoBrek.Core.ViewModel
{
    //[Table("StreamQuality")]
    public class  StreamQualityVM
    {
        public int Id { get; set; }
        public string StreatQualityName { get; set; }
        public bool IsActive { get; set; }
        public string CreatedDtTm { get; set; }
        public int CreatedBy { get; set; }
        public virtual List<UserProfileConfigVM> UserProfileConfig { get; set; }
    }
}
