namespace VideoBrek.Models
{
    public class UserMyListModel
    {
        public int UserMyListId { get; set; }
        public int UserId { get; set; }
        public int MediaId { get; set; }
        public string CreateDtTm { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public MediaModel Media { get; set; }
        public UserProfileModel User { get; set; }
    }
}