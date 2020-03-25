using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VideoBrekWebApi.Models
{
    public class DBContexVideoApp: DbContext
    {
        public DBContexVideoApp():base("DefaultConnection")
        {

        }
        public DbSet<UserProfileModel> UserProfile { get; set; }
        public DbSet<UserProfileConfigModel> UserProfileConfig { get; set; }

        //public DbSet<StreamQualityModel> StreamQuality { get; set; }
        //public DbSet<MediaModel> Media { get; set; }
        //public DbSet<UserMyListModel> UserMyList { get; set; }

        //public DbSet<UserDeviceModel> UserDevice { get; set; }
        //public DbSet<MediaTypeModel> MediaType { get; set; }
    }
}