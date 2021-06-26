using System;
using System.Collections.Generic;

namespace VideoBrek.Models
{
    public class ResultModel
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string success { get; set; }
        public string result { get; set; }
        public object Response { get; set; }
        public string accessToken { get; set; }
        public int userId { get; set; }
    }

    

}
