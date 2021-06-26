namespace VideoBrek.Models
{
    public class AppLoginModel
    {
        //public string Email { get; set; }
        public string userNameOrEmailAddress { get; set; }
        public  bool rememberClient { get; set; }
        public string Password { get; set; }
    }

    public class PasswordResetModel
    {
        public string Email { get; set; }
    }
}
