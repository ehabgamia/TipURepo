using System;
namespace VideoBrekWebApi.Models
{
    public class ResultModel
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Response { get; set; }
    }
}
