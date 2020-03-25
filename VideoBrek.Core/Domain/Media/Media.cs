using System;
using System.Collections.Generic;
using System.Text;

namespace VideoBrek.Core.Domain.Media
{
  public  class Media : BaseEntity
    {
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
        public int MediaTypeId { get; set; }
        public virtual MediaType MediaType { get; set; }
    }
}
