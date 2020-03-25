using System;
namespace VideoBrekWebApi.ViewModels
{
    public class VideoAppResult
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Response { get; set; }
    }
}
