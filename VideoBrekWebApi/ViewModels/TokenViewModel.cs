using System;
namespace VideoBrekWebApi.ViewModels
{
    public class TokenViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string grant_type { get; set; }
        public string access_token { get; set; }
    }
}
