using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBrek.Core.Domain.Category;
using VideoBrek.Core.Domain.Media;

namespace VideoBrek.Data
{
   public partial class DBContexVideoApp:DbContext
    {

        public DBContexVideoApp() : base("DefaultConnection")
        {

        }
        public virtual DbSet<MediaCategory> MediaCategory { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<MediaType> MediaTypes { get; set; }
    }
}
