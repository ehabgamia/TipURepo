using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VideoBrekWebApi.Models
{
    [Table("UserMyList")]
    public class UserMyListModel
    {
        public int Id { get; set; }

        public string CreateDtTm { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }

        public virtual MediaModel Media { get; set; }
        public int MediaId { get; set; }
        public virtual UserProfileModel User { get; set; }
        public int UserId { get; set; }
    }
}