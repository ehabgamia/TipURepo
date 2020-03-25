


namespace VideoBrek.Core.Domain.Category
{
    //[Table("MediaCategory")]

 public   class MediaCategory: BaseEntity
    {
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public string CreateDtTm { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
