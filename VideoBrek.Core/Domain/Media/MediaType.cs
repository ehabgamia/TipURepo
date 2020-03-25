using System;
using System.Collections.Generic;
using System.Text;

namespace VideoBrek.Core.Domain.Media
{
  public  class MediaType:BaseEntity
    {
        public string MediaTypeName { get; set; }
        public bool IsActive { get; set; }
        public string CreateDtTm { get; set; }
        public int CreatedBy { get; set; }
    }
}
