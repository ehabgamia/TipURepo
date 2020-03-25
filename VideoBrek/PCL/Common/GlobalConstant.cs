using System;
using System.Collections.Generic;
using VideoBrek.Models;

namespace VideoBrek.PCL.Common
{
    public class GlobalConstant
    {
        public static string BaseUrl = "http://18.222.14.240:8074/api/";
        //public static string BaseUrl = "http://graceanointing.org/_api/";
        public static string AccessToken { get; set; }
        public static double? Latitude { get; set; }
        public static double? Longitude { get; set; }

        public static double? Altitude { get; set; }
        public static UserProfileModel UserProfileDetails { get; set; }
        public static List<int> MyListIds { get; set; }
    }

    public struct AppUsersUrl
    {
        //public static string authenticate = "appusers/authenticate";
        public static string Login = "AccountAPI/Login";
        //public static string register = "appusers/register";
        public static string Register = "AccountAPI/Register";
        public static string resetpassword = "appusers/resetpassword?email=";
    }

    public struct MediaHandlerUrl
    {
        public static string getMedias = "MediaHandler/getMedias";
        public static string addtomylist = "MediaHandler/addtomylist";
        public static string getTermsAgreement = "MediaHandler/getTermsAgreement";
        public static string searchmedia = "MediaHandler/searchmedia";
        public static string getsettings = "MediaHandler/getsettings";
        public static string UpdateSettings = "MediaHandler/UpdateSettings";
        
    }
}