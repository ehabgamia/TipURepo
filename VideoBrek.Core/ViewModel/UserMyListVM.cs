using System;
using System.Collections.Generic;
using System.Text;

namespace VideoBrek.Core.ViewModel
{
    //[Table("UserMyList")]
    public class UserMyListVM
    {
        public int Id { get; set; }

        public string CreateDtTm { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }

        //public virtual MediaCategoryVM Media { get; set; }
        public int MediaId { get; set; }
        public virtual UserProfileVM User { get; set; }
        public int UserId { get; set; }
    }
}